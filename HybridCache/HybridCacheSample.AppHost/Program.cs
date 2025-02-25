var builder = DistributedApplication.CreateBuilder(args);

var redis = builder.AddRedis("rediscache").WithRedisInsight();

builder.AddProject<Projects.HybridCacheSample_Api>("HybridCacheSample-api")
    .WithReference(redis)
    .WaitFor(redis);

builder.Build().Run();
