﻿using Microsoft.Extensions.Configuration;
using Microsoft.Azure.Cosmos;
using CapitalPlacementProject.Models; // Assuming you have models in a "Models" namespace or folder
using System;

namespace CapitalPlacementProject.Data
{
    public class CapitalPlacementDbContext
    {
        private readonly string _endpointUri;
        private readonly string _primaryKey;
        private readonly CosmosClient _cosmosClient;
        private readonly string _databaseId = "CapitalPlacementDb"; // Ensure this matches your actual database name

        public CapitalPlacementDbContext(IConfiguration configuration)
        {
            _endpointUri = configuration["CosmosDb:EndpointUri"];
            _primaryKey = configuration["CosmosDb:PrimaryKey"];

            _cosmosClient = new CosmosClient(_endpointUri, _primaryKey);
        }

        public Container ProgramContainer => _cosmosClient.GetContainer(_databaseId, "Program");
        public Container ApplicationTemplateContainer => _cosmosClient.GetContainer(_databaseId, "ApplicationTemplate");
        public Container WorkflowContainer => _cosmosClient.GetContainer(_databaseId, "Workflow");
        public Container PreviewContainer => _cosmosClient.GetContainer(_databaseId, "Preview");
    }
}
