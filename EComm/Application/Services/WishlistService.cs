﻿using EComm.Domain.Models;
using EComm.Infrastructure.Interfaces;

namespace EComm.Application.Services
{
    public class WishlistService
    {
        private readonly IWishListRepository _wishlistRepository;

        public WishlistService(IWishListRepository wishlistRepository)
        {
            _wishlistRepository = wishlistRepository;
        }

        public async Task<IEnumerable<WishList>> GetWishlistByUser(string userId)
        {
            return await _wishlistRepository.GetWishlistByUser(userId);
        }


        public async Task<bool> AddToWishlist(string userId, int productId)
        {
            var existingItem = await _wishlistRepository.GetWishListItem(userId,productId);
            if (existingItem != null)
            {
                return false;
            }
            var wishlistItem = new WishList { CustomerId = userId, ProductId = productId };
            await _wishlistRepository.AddToWishlist(wishlistItem);
            return true;
        }

        public async Task<bool> RemoveFromWishlist(string userId, int productId)
        {
            var existingItem = await _wishlistRepository.GetWishListItem(userId, productId);
            if (existingItem == null)
            {
                return false;
            }
            await _wishlistRepository.RemoveFromWishlist(existingItem.Id);
            return true;
        }
    }
}
