using PracticeDemoWithAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PracticeDemoWithAngular.Controllers
{
    public class CustomerController : ApiController
    {
        //get all customer
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return GetAll();
        }

        //get customer by id
        public Customer Get(int id)
        {
            Customer customer = GetOne();

            if (customer == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return customer;
        }

        [HttpPost]
        public HttpResponseMessage Post123(Customer customer)
        {
            if (ModelState.IsValid)
            {
                //   db.Customers.Add(customer);
                //  db.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, customer);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = customer.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        //insert customer
        //public HttpResponseMessage Post(Customer customer)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //   db.Customers.Add(customer);
        //        //  db.SaveChanges();
        //        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, customer);
        //        response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = customer.Id }));
        //        return response;
        //    }
        //    else
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //    }
        //}

        //update customer
        public HttpResponseMessage Put(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            if (id != customer.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            //db.Entry(customer).State = EntityState.Modified;
            //  try
            //  {
            //      db.SaveChanges();
            //  }
            //  catch (DbUpdateConcurrencyException ex)
            //  {
            //      return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            //  }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        //delete customer by id
        public HttpResponseMessage Delete(int id)
        {
            Customer customer = GetOne();

            if (customer == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            /*  db.Customers.Remove(customer);
              try
              {
                  db.SaveChanges();
              }
              catch (DbUpdateConcurrencyException ex)
              {
                  return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
              }
              */

            return Request.CreateResponse(HttpStatusCode.OK, customer);
        }

        private Customer GetOne()
        {
            return new Customer { Id = 1, Name = "Customer1", Address = "56,Farrow Avenue", Age = 23, City = "Peterborough", Country = "UK", DateOfBirth = DateTime.Parse("20/12/1983") };
        }

        private List<Customer> GetAll()
        {
            return new List<Customer> {
                new Customer { Id=1, Name="Customer1", Address="56,Farrow Avenue", Age=23, City="Peterborough", Country="UK", DateOfBirth=DateTime.Parse("20/12/1983") },
                new Customer { Id=2, Name="Customer2", Address="56,Farrow Avenue", Age=78, City="Peterborough", Country="UK", DateOfBirth=DateTime.Parse("20/12/1984") },
                new Customer { Id=3, Name="Customer3", Address="56,Farrow Avenue", Age=65, City="Peterborough", Country="UK", DateOfBirth=DateTime.Parse("20/12/1985") },
                new Customer { Id=4, Name="Customer4", Address="56,Farrow Avenue", Age=45, City="Peterborough", Country="UK", DateOfBirth=DateTime.Parse("20/12/1986") },
                new Customer { Id=5, Name="Customer5", Address="56,Farrow Avenue", Age=25, City="Peterborough", Country="UK", DateOfBirth=DateTime.Parse("20/12/1987") }

        };
        }

    }
}
