// Third-party libraries
global using MediatR;
global using FluentValidation;

// Internal libraries
global using Blocks.Core;
global using Blocks.MediatR;
global using Blocks.EntityFramework;
global using Articles.Abstractions;
global using Articles.Abstractions.Enums;

// Domain
global using Submission.Domain.Entities;
global using Submission.Domain.Enums;
global using Submission.Domain.ValueObjects;

// Application
global using Submission.Application.Features.Shared;

//Persistence
global using Submission.Persistence;
global using Submission.Persistence.Repositories;

global using AssetTypeDefinitionRepository = Blocks.EntityFramework.CachedRepository<
        Submission.Persistence.SubmissionDbContext,
        Submission.Domain.Entities.AssetTypeDefinition,
        Articles.Abstractions.Enums.AssetType>;
