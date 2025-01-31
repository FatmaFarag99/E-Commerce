﻿namespace ECommerce
{
    using ECommerce.Common;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<List<Category>> GetAllAsync()
        {
            return await _table
                .Include(c => c.Products)
                .ToListAsync();
        }

        public override async Task<Category> GetByIdAsync(Guid id)
        {
            return await _table
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}