using Microsoft.EntityFrameworkCore;
using Restaurant.Services.Email.DbContexts;
using Restaurant.Services.Email.Messages;
using Restaurant.Services.Email.Modules;

namespace Restaurant.Services.Email.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly DbContextOptions<ApplicationDbContext> _dbContext;

        public EmailRepository(DbContextOptions<ApplicationDbContext> dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SendAndLogEmail(UpdatePaymentResultMessage message)
        {
            //implement an email sender or call some other class library
            EmailLog emailLog = new()
            {
                Email = message.Email,
                EmailSent = DateTime.Now,
                Log = $"Order - {message.OrderId} has been created successfully"
            };

            await using var _db = new ApplicationDbContext(_dbContext);
            _db.EmailLogs.Add(emailLog);
            await _db.SaveChangesAsync();
        }
    }
}
