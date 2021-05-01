using ShopBridge.DTOs;
using ShopBridge.Models;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace ShopBridge.Controllers.APIs
{
    public class ItemsController : ApiController
    {
        private MyDbContext _context;
        public ItemsController()
        {
            _context = new MyDbContext();
        }

        // Get api/items
        public IHttpActionResult GetItems()
        {
            var itemDtos = _context.Items
                .Include(c=>c.Category)
                .ToList()
                .Select(Mapper.Map<Item, ItemDTO>);

            return Ok(itemDtos);
        }


        // Get api/items/id
        public IHttpActionResult GetItems(int id)
        {
            var item = _context.Items.FirstOrDefault(c => c.Id == id);
            if (item == null)
                return NotFound();

            return Ok(Mapper.Map<Item, ItemDTO>(item));
        }

        // Post api/items
        [HttpPost]
        public IHttpActionResult CreateItem(ItemDTO itemDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var item = Mapper.Map<ItemDTO, Item>(itemDTO);

            _context.Items.Add(item);
            _context.SaveChanges();

            itemDTO.Id = item.Id;

            return Created(new Uri(Request.RequestUri + "/" + item.Id), itemDTO);
        }

        // Put api/items/1
        [HttpPut]
        public IHttpActionResult UpdateItem(ItemDTO itemDTO, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var ItemInDb = _context.Items.SingleOrDefault(c => c.Id == id);

            if (ItemInDb == null)
                return NotFound();

            Mapper.Map(itemDTO, ItemInDb);

            _context.SaveChanges();

            return Ok();
        }

        // Delete api/items/id
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var ItemInDb = _context.Items.SingleOrDefault(c => c.Id == id);

            if (ItemInDb == null)
                return NotFound();

            _context.Items.Remove(ItemInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
