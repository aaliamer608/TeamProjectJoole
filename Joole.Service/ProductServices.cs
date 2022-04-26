﻿using Joole.Data.Data;
using Joole.Repo;
using Joole.Repo.Repositories;
using Joole.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joole.Service
{

    public class ProductServices
    {
        public UnitOfWork uow { get; set; }
        public JooleDBEntities _context;


        //GenericRepository<tblProduct> genRepo;
        public ProductServices()
        {

            this._context = new JooleDBEntities();
            this.uow = new UnitOfWork(_context);
            //_context = new JooleDBEntities();

            //genRepo = new GenericRepository<tblProduct>(_context);
        }


        //public List<tblCategory> getAllProducts()
        //{


        //    //return genRepo.GetAll().ToList();
        //}


        public void productAdd(ProductDTO productDTO)
        {
            tblProduct obj = new tblProduct()
            {
                //Product_ID = productDTO.ProductId,
                Product_Name = productDTO.Product_Name

            };
            uow.Products.Add(obj);
            uow.Complete();
        }


        public List<tblProduct> getAllProducts()
        {

            var res = uow.Products.GetAll();
            //uow.Complete();
            return (List<tblProduct>)res;
        }


        public IEnumerable<ProductDTO> getProductByName(string name)
        {
            var product = uow.Products.GetAll();

            var result = (
                from p in product
                where p.Product_Name.Equals(name, StringComparison.OrdinalIgnoreCase)
                select new ProductDTO
                {
                    //ProductId = p.Product_ID,
                    Product_Name = p.Product_Name
                }
                ).ToList();

            //uow.Complete();

            return result;
        }

        //public List<ProductDTO> getProductByID(int id)
        //{
        //    var products = uow.Products.GetAll();

        //    var result = (
        //        from p in products
        //        where p.Product_ID == id
        //        select products
        //        ).ToList();
        //    var res = uow.Products.GetById(id);
        //    //uow.Complete();
        //    return res;
        //}
    }
}
