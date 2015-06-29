// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using JetBrains.Annotations;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Relational;
using Npgsql.EntityFramework7;
using Npgsql.EntityFramework7.Migrations;
using Npgsql.EntityFramework7.Query;
using Npgsql.EntityFramework7.Update;
using Microsoft.Data.Entity.Storage;
using Microsoft.Data.Entity.Utilities;
using Npgsql;
using Npgsql.EntityFramework7.Metadata;
using Npgsql.EntityFramework7.ValueGeneration;

// ReSharper disable once CheckNamespace

namespace Microsoft.Framework.DependencyInjection
{
    public static class NpgsqlEntityServicesBuilderExtensions
    {
        public static EntityFrameworkServicesBuilder AddNpgsql([NotNull] this EntityFrameworkServicesBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.AddRelational().GetService()
                .AddSingleton<IDatabaseProvider, NpgsqlDatabaseProvider>()
                .TryAdd(new ServiceCollection()
                    .AddSingleton<NpgsqlConventionSetBuilder>()
                    .AddSingleton<INpgsqlValueGeneratorCache, NpgsqlValueGeneratorCache>()
                    .AddSingleton<INpgsqlSqlGenerator, NpgsqlSqlGenerator>()
                    .AddSingleton<NpgsqlTypeMapper>()
                    .AddSingleton<NpgsqlModelSource>()
                    .AddSingleton<NpgsqlMetadataExtensionProvider>()
                    .AddSingleton<NpgsqlMigrationAnnotationProvider>()
                    .AddScoped<INpgsqlSequenceValueGeneratorFactory, NpgsqlSequenceValueGeneratorFactory>()
                    .AddScoped<NpgsqlModificationCommandBatchFactory>()
                    .AddScoped<NpgsqlValueGeneratorSelector>()
                    .AddScoped<NpgsqlDatabaseProviderServices>()
                    .AddScoped<NpgsqlDatabase>()
                    .AddScoped<NpgsqlDatabaseConnection>()
                    .AddScoped<NpgsqlMigrationSqlGenerator>()
                    .AddScoped<NpgsqlDatabaseCreator>()
                    .AddScoped<NpgsqlHistoryRepository>()
                    .AddScoped<NpgsqlCompositeMethodCallTranslator>()
                    .AddScoped<NpgsqlCompositeMemberTranslator>());

            return builder;
        }
    }
}