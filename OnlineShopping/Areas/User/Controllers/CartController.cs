﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Infrastructure;
using OnlineShopping.Models;
using OnlineShopping.Models.ViewModels;


namespace OnlineShopping.Controllers
{
        [Area("User")]
        
        public class CartController : Controller
        {
            private IProductRepository repository;
            private Cart cart;
            public CartController(IProductRepository repo, Cart cartService)
            {
                repository = repo;
                cart = cartService;
            }
            public ViewResult Index(string returnUrl)
            {
                return View(new CartIndexViewModel
                {
                    Cart = cart,
                    ReturnUrl = returnUrl
                });
            }
            
 public RedirectToActionResult AddToCart(int productId, string returnUrl)
            {
                Product product = repository.Products
                .FirstOrDefault(p => p.ProductId == productId);
                if (product != null)
                {
                    cart.AddItem(product, 1);
                }
                return RedirectToAction("Index", new { returnUrl });
            }
            public RedirectToActionResult RemoveFromCart(int productId,
            string returnUrl)
            {
                Product product = repository.Products
                .FirstOrDefault(p => p.ProductId == productId);
                if (product != null)
                {
                    cart.RemoveLine(product);
                }
                return RedirectToAction("Index", new { returnUrl });
            }
        }
    }