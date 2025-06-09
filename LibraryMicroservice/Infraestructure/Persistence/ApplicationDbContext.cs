﻿using Application.Data;
using Domain.Entities.Loan;
using Domain.Entities.PaymentMethod;
using Domain.Primitives;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext, IUnitOfWorks
    {
        private readonly IPublisher _publisher;
        
        public ApplicationDbContext(DbContextOptions options, IPublisher publisher) : base(options)
        {
            _publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
        }

        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<LoanDetail> LoanDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var domainEvents = ChangeTracker.Entries<AggregateRoot>()
                .Select(e => e.Entity)
                .Where(e => e.GetDomainEvents().Any())
                .SelectMany(e => e.GetDomainEvents());

            var result = await base.SaveChangesAsync(cancellationToken);

            foreach (var domainEvent in domainEvents)
            {
                await _publisher.Publish(domainEvent, cancellationToken);
            }
            return result;
        }
    }
}
