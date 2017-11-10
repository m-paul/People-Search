using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeopleSearch.DataAccess;
using Rhino.Mocks;
using System.Collections.Generic;
using System.Linq;
using PeopleSearch.DataAccess.Entities;
using PeopleSearch.WebApi.Models;
using PeopleSearch.WebApi.Controllers;
using PeopleSearch.WebApi.BusinessLogic;

namespace PeopleSearch.WebApi.Test
{
    [TestClass]
    public class PersonManagerTest
    {
        private delegate List<TResult> GetListTranformationDelegate<TEntity, TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> transformBy) where TEntity : class;

        private IPeopleSearchDAL _dal;
        private IPersonManager _manager;

        [TestInitialize]
        public void Initialize()
        {
            _dal = MockRepository.GenerateStub<IPeopleSearchDAL>();
            _manager = new PersonManager(_dal);
        }

        [TestMethod]
        public void NameSearchNoCriteria_Test()
        {
            // Generate persons
            var persons = new List<Person>
            {
                new Person { FirstName = "Anne", LastName = "Arnette" },
                new Person { FirstName = "Belle", LastName = "Brook" },
            };

            // Configure DAL
            var personsQuery = persons.AsQueryable();
            _dal.Stub(x => x.GetList(Arg<Func<IQueryable<Person>, IQueryable<PersonDto>>>.Is.Anything))
                .Do((GetListTranformationDelegate<Person, PersonDto>)(transformBy => transformBy(personsQuery).ToList()));
            
            // Execute test
            var result = _manager.Search(null);

            // Verify results
            Assert.AreEqual(persons.Count, result.Count);
        }

        [TestMethod]
        public void NameSearchNoName_Test()
        {
            // Generate persons
            var persons = new List<Person>
            {
                new Person { FirstName = "Anne", LastName = "Arnette" },
                new Person { FirstName = "Belle", LastName = "Brook" },
            };

            // Configure DAL
            var personsQuery = persons.AsQueryable();
            _dal.Stub(x => x.GetList(Arg<Func<IQueryable<Person>, IQueryable<PersonDto>>>.Is.Anything))
                .Do((GetListTranformationDelegate<Person, PersonDto>)(transformBy => transformBy(personsQuery).ToList()));

            // Configure criteria
            var criteria = new PersonSearchCriteriaDto { Name = null };

            // Execute test
            var result = _manager.Search(criteria);

            // Verify results
            Assert.AreEqual(persons.Count, result.Count);
        }

        [TestMethod]
        public void NameSearchNotFound_Test()
        {
            // Generate persons
            var persons = new List<Person>
            {
                new Person { FirstName = "Anne", LastName = "Arnette" },
                new Person { FirstName = "Belle", LastName = "Brook" },
            };

            // Configure DAL
            var personsQuery = persons.AsQueryable();
            _dal.Stub(x => x.GetList(Arg<Func<IQueryable<Person>, IQueryable<PersonDto>>>.Is.Anything))
                .Do((GetListTranformationDelegate<Person, PersonDto>)(transformBy => transformBy(personsQuery).ToList()));

            // Configure criteria
            var criteria = new PersonSearchCriteriaDto { Name = "xxx" };

            // Execute test
            var result = _manager.Search(criteria);

            // Verify results
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void NameSearchFound_Test()
        {
            // Generate persons
            var persons = new List<Person>
            {
                new Person { FirstName = "Anne", LastName = "Arnette" },
                new Person { FirstName = "Belle", LastName = "Brook" },
            };
            
            // Configure DAL
            var personsQuery = persons.AsQueryable();
            _dal.Stub(x => x.GetList(Arg<Func<IQueryable<Person>, IQueryable<PersonDto>>>.Is.Anything))
                .Do((GetListTranformationDelegate<Person, PersonDto>)(transformBy => transformBy(personsQuery).ToList()));

            // Configure criteria
            // Special Note: Linq to SQL will, by default, perform a case-insensitive search if the table is using
            //               default collation. Linq to Objects, on the otherhand, will not. Keep that in mind when testing.
            var criteria = new PersonSearchCriteriaDto { Name = " ll  " };
            
            // Execute test
            var result = _manager.Search(criteria);

            // Verify results
            Assert.AreEqual(1, result.Count);

            var match = result.First();
            Assert.AreEqual("Belle", match.FirstName);
            Assert.AreEqual("Brook", match.LastName);
        }
    
    }
}
