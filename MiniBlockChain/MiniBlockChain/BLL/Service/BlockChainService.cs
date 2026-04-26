using DAL.Contetx;
using Domains.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class BlockchainService
    {
        private readonly AppDbContext _context;
        private readonly HashService _hash;

        public BlockchainService(AppDbContext context, HashService hash)
        {
            _context = context;
            _hash = hash;
        }

        public async Task<BlockChain> AddBlock(string document)
        {
            var documentHash = _hash.CreateHash(document);

            var lastBlock = await _context.Blocks
                .OrderByDescending(x => x.Id)
                .FirstOrDefaultAsync();

            var previousHash = lastBlock?.DocumentHash ?? "0";

            var block = new BlockChain
            {
                DocumentHash = documentHash,
                PreviousHash = previousHash,
                Timestamp = DateTime.UtcNow
            };

            _context.Blocks.Add(block);
            await _context.SaveChangesAsync();

            return block;
        }

        public async Task<bool> ValidateChain()
        {
            var blocks = await _context.Blocks
                .OrderBy(x => x.Id)
                .ToListAsync();

            for (int i = 1; i < blocks.Count; i++)
            {
                if (blocks[i].PreviousHash != blocks[i - 1].DocumentHash)
                    return false;
            }

            return true;
        }
    }
}
