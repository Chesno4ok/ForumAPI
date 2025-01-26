using k8s.Models;
using Projects;

var builder = DistributedApplication.CreateBuilder(args);

// Services

// Redis
var cache = builder.AddRedis("cache", 6379)
    .WithRedisInsight();

// Postgres
var postgres = builder.AddPostgres("postgres", port: 5432).WithPgAdmin();

var postgresdb = postgres.AddDatabase("postgresDb");



// Projects
var api = builder.AddProject<Forum_API>("forum-api")
    .WithReference(cache)
    .WithReference(postgres)
    .WithReference(postgresdb);

builder.AddProject<Projects.Forum_MigrationService>("forum-migrationservice")
    .WithReference(postgresdb)
    .WithReference(postgres);

// etc




// etc

builder.Build().Run();
