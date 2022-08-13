﻿using AutoMapper;
using BookReservation.Data.Entities;
using BookReservation.Server.Services;
using BookReservation.Server.Services.Abstract;
using BookReservation.Shared.Dtos.Book;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookReservation.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService bookService;
        private readonly IMapper _mapper;

        public BooksController(IBookService bookService, IMapper mapper)
        {
            this.bookService = bookService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var manager = new ServiceManager<Book, BookGetAllDto>(bookService, _mapper);

            var data = await manager.GetAll();

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var manager = new ServiceManager<Book, BookGetByIdDto>(bookService, _mapper);

            var data = await manager.GetSingle(id);

            return Ok(data);
        }
    }
}
