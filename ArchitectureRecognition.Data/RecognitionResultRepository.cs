using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArchitectureRecognition.Services.Data.Abstract;
using ArchitectureRecognition.Services.Data.Entities;

namespace ArchitectureRecognition.Data
{
    public sealed class RecognitionResultRepository : IRecognitionResultRepository
    {
        private readonly AppDbContext _dbContext;

        public RecognitionResultRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void AddRecognitionResult(RecognitionResult task)
        {
            _dbContext.Add(task);
        }

        public async Task<List<RecognitionResult>> GetAllRecognitionResultsAync(string userId)
        {
            return await _dbContext.RecognitionResults.Where(r => r.UserId == userId).ToListAsync();
        }

        public async Task<RecognitionResult> FindByIdAsync(int id)
        {
            return await _dbContext.RecognitionResults.FindAsync(id);
        }

        public void Update(RecognitionResult recognitionResult)
        {
            _dbContext.RecognitionResults.Update(recognitionResult);
        }

        public void Delete(RecognitionResult recognitionResult)
        {
            _dbContext.Entry(recognitionResult).State = EntityState.Deleted;
        }
    }
}
