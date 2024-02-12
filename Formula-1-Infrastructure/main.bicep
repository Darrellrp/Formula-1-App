param containerapps_db_name string = 'db'
param containerapps_api_name string = 'api'
param containerapps_ops_name string = 'ops'
param containerapps_web_name string = 'web'
param containerapps_cache_name string = 'cache'
param managedEnvironments_formula_1_app_env_name string = 'formula-1-app-env'
param storageAccounts_f1appstorageaccount_name string = 'f1appstorageaccount'
param registries_formula1registry_name string = 'formula1registry'
param userAssignedIdentities_formula_1_pipline_uami_name string = 'formula-1-pipline-uami'
param workspaces_workspace_ormula1esourceroup8kTI_name string = 'workspace-ormula1esourceroup8kTI'
param workspaces_workspace_ormula1esourceroupfTso_name string = 'workspace-ormula1esourceroupfTso'
param workspaces_workspace_ormula1esourceroupmbEl_name string = 'workspace-ormula1esourceroupmbEl'
param workspaces_workspace_ormula1esourceroupoonw_name string = 'workspace-ormula1esourceroupoonw'
param workspaces_workspace_ormula1esourceroupzsb4_name string = 'workspace-ormula1esourceroupzsb4'
param location string = 'West Europe'

resource managedEnvironments_formula_1_app_env_name_resource 'Microsoft.App/managedEnvironments@2023-08-01-preview' = {
  name: managedEnvironments_formula_1_app_env_name
  location: location
  properties: {
    appLogsConfiguration: {
      destination: 'log-analytics'
      logAnalyticsConfiguration: {
        customerId: 'c9e0c3b2-ce5c-45cd-80b0-ea8d366246b2'
        dynamicJsonColumns: false
      }
    }
    zoneRedundant: false
    kedaConfiguration: {}
    daprConfiguration: {}
    customDomainConfiguration: {}
    workloadProfiles: [
      {
        workloadProfileType: 'Consumption'
        name: 'Consumption'
      }
    ]
    peerAuthentication: {
      mtls: {
        enabled: false
      }
    }
  }
}

resource registries_formula1registry_name_resource 'Microsoft.ContainerRegistry/registries@2023-11-01-preview' = {
  name: registries_formula1registry_name
  location: location
  sku: {
    name: 'Basic'
    // tier: 'Basic'
  }
  properties: {
    adminUserEnabled: true
    policies: {
      quarantinePolicy: {
        status: 'disabled'
      }
      trustPolicy: {
        type: 'Notary'
        status: 'disabled'
      }
      retentionPolicy: {
        days: 7
        status: 'disabled'
      }
      exportPolicy: {
        status: 'enabled'
      }
      azureADAuthenticationAsArmPolicy: {
        status: 'enabled'
      }
      softDeletePolicy: {
        retentionDays: 7
        status: 'disabled'
      }
    }
    encryption: {
      status: 'disabled'
    }
    dataEndpointEnabled: false
    publicNetworkAccess: 'Enabled'
    networkRuleBypassOptions: 'AzureServices'
    zoneRedundancy: 'Disabled'
    anonymousPullEnabled: false
    metadataSearch: 'Disabled'
  }
}

resource userAssignedIdentities_formula_1_pipline_uami_name_resource 'Microsoft.ManagedIdentity/userAssignedIdentities@2023-07-31-preview' = {
  name: userAssignedIdentities_formula_1_pipline_uami_name
  location: location
}

resource workspaces_workspace_ormula1esourceroup8kTI_name_resource 'Microsoft.OperationalInsights/workspaces@2021-12-01-preview' = {
  name: workspaces_workspace_ormula1esourceroup8kTI_name
  location: location
  properties: {
    sku: {
      name: 'PerGB2018'
    }
    retentionInDays: 30
    features: {
      enableLogAccessUsingOnlyResourcePermissions: true
    }
    workspaceCapping: {
      dailyQuotaGb: -1
    }
    publicNetworkAccessForIngestion: 'Enabled'
    publicNetworkAccessForQuery: 'Enabled'
  }
}

resource workspaces_workspace_ormula1esourceroupfTso_name_resource 'Microsoft.OperationalInsights/workspaces@2021-12-01-preview' = {
  name: workspaces_workspace_ormula1esourceroupfTso_name
  location: location
  properties: {
    sku: {
      name: 'PerGB2018'
    }
    retentionInDays: 30
    features: {
      enableLogAccessUsingOnlyResourcePermissions: true
    }
    workspaceCapping: {
      dailyQuotaGb: -1
    }
    publicNetworkAccessForIngestion: 'Enabled'
    publicNetworkAccessForQuery: 'Enabled'
  }
}

resource workspaces_workspace_ormula1esourceroupmbEl_name_resource 'Microsoft.OperationalInsights/workspaces@2021-12-01-preview' = {
  name: workspaces_workspace_ormula1esourceroupmbEl_name
  location: location
  properties: {
    sku: {
      name: 'PerGB2018'
    }
    retentionInDays: 30
    features: {
      enableLogAccessUsingOnlyResourcePermissions: true
    }
    workspaceCapping: {
      dailyQuotaGb: -1
    }
    publicNetworkAccessForIngestion: 'Enabled'
    publicNetworkAccessForQuery: 'Enabled'
  }
}

resource workspaces_workspace_ormula1esourceroupoonw_name_resource 'Microsoft.OperationalInsights/workspaces@2021-12-01-preview' = {
  name: workspaces_workspace_ormula1esourceroupoonw_name
  location: location
  properties: {
    sku: {
      name: 'PerGB2018'
    }
    retentionInDays: 30
    features: {
      enableLogAccessUsingOnlyResourcePermissions: true
    }
    workspaceCapping: {
      dailyQuotaGb: -1
    }
    publicNetworkAccessForIngestion: 'Enabled'
    publicNetworkAccessForQuery: 'Enabled'
  }
}

resource workspaces_workspace_ormula1esourceroupzsb4_name_resource 'Microsoft.OperationalInsights/workspaces@2021-12-01-preview' = {
  name: workspaces_workspace_ormula1esourceroupzsb4_name
  location: location
  properties: {
    sku: {
      name: 'PerGB2018'
    }
    retentionInDays: 30
    features: {
      enableLogAccessUsingOnlyResourcePermissions: true
    }
    workspaceCapping: {
      dailyQuotaGb: -1
    }
    publicNetworkAccessForIngestion: 'Enabled'
    publicNetworkAccessForQuery: 'Enabled'
  }
}

resource storageAccounts_f1appstorageaccount_name_resource 'Microsoft.Storage/storageAccounts@2023-01-01' = {
  name: storageAccounts_f1appstorageaccount_name
  location: location
  sku: {
    name: 'Standard_LRS'
    // tier: 'Standard'
  }
  kind: 'StorageV2'
  properties: {
    minimumTlsVersion: 'TLS1_0'
    allowBlobPublicAccess: true
    networkAcls: {
      bypass: 'AzureServices'
      virtualNetworkRules: []
      ipRules: []
      defaultAction: 'Allow'
    }
    supportsHttpsTrafficOnly: true
    encryption: {
      services: {
        file: {
          keyType: 'Account'
          enabled: true
        }
        blob: {
          keyType: 'Account'
          enabled: true
        }
      }
      keySource: 'Microsoft.Storage'
    }
    accessTier: 'Hot'
  }
}

resource containerapps_cache_name_resource 'Microsoft.App/containerapps@2023-08-01-preview' = {
  name: containerapps_cache_name
  location: location
  identity: {
    type: 'None'
  }
  properties: {
    managedEnvironmentId: managedEnvironments_formula_1_app_env_name_resource.id
    environmentId: managedEnvironments_formula_1_app_env_name_resource.id
    workloadProfileName: 'Consumption'
    configuration: {
      secrets: [
        {
          name: 'formula1registryazurecrio-formula1registry'
        }
      ]
      activeRevisionsMode: 'Single'
      ingress: {
        external: false
        targetPort: 6379
        exposedPort: 6379
        transport: 'Tcp'
        traffic: [
          {
            weight: 100
            latestRevision: true
          }
        ]
        allowInsecure: false
        stickySessions: {
          affinity: 'none'
        }
      }
      registries: [
        {
          server: 'formula1registry.azurecr.io'
          username: 'formula1registry'
          passwordSecretRef: 'formula1registryazurecrio-formula1registry'
        }
      ]
    }
    template: {
      containers: [
        {
          image: 'formula1registry.azurecr.io/formula-1-${containerapps_cache_name}:dc054c92bc256a1b9fbd0d41d1a765a655a48bf0'
          name: containerapps_cache_name
          resources: {
            // cpu: '0.25'
            memory: '0.5Gi'
          }
          probes: []
        }
      ]
      scale: {
        minReplicas: 1
        maxReplicas: 1
      }
      volumes: []
    }
  }
}

resource containerapps_db_name_resource 'Microsoft.App/containerapps@2023-08-01-preview' = {
  name: containerapps_db_name
  location: location
  identity: {
    type: 'None'
  }
  properties: {
    managedEnvironmentId: managedEnvironments_formula_1_app_env_name_resource.id
    environmentId: managedEnvironments_formula_1_app_env_name_resource.id
    workloadProfileName: 'Consumption'
    configuration: {
      secrets: [
        {
          name: 'formula1registryazurecrio-formula1registry'
        }
        {
          name: 'reg-pswd-cd9069eb-ac27'
        }
      ]
      activeRevisionsMode: 'Single'
      ingress: {
        external: false
        targetPort: 3306
        exposedPort: 3306
        transport: 'Tcp'
        traffic: [
          {
            weight: 100
            latestRevision: true
          }
        ]
        allowInsecure: false
        stickySessions: {
          affinity: 'none'
        }
      }
      registries: [
        {
          server: 'formula1registry.azurecr.io'
          username: 'formula1registry'
          passwordSecretRef: 'formula1registryazurecrio-formula1registry'
        }
      ]
    }
    template: {
      containers: [
        {
          image: 'formula1registry.azurecr.io/${containerapps_db_name}:dc054c92bc256a1b9fbd0d41d1a765a655a48bf0'
          name: containerapps_db_name
          env: [
            {
              name: 'MYSQL_DATABASE'
              value: 'Formula1App_Database'
            }
            {
              name: 'MYSQL_USER'
              value: 'admin'
            }
            {
              name: 'MYSQL_PASSWORD'
              value: 'vDQr62VsmXNV6aMmy'
            }
            {
              name: 'MYSQL_ROOT_PASSWORD'
              value: 'RJvRuyFJLssrJ8jeeDY4'
            }
          ]
          resources: {
            // cpu: '0.25'
            memory: '0.5Gi'
          }
          probes: []
        }
      ]
      scale: {
        minReplicas: 1
        maxReplicas: 1
      }
      volumes: [
        {
          name: 'mysql'
          storageType: 'AzureFile'
          storageName: 'mysql'
        }
        {
          name: 'f1-mysql'
          storageType: 'AzureFile'
          storageName: 'f1-mysql'
        }
      ]
    }
  }
}

resource containerapps_ops_name_resource 'Microsoft.App/containerapps@2023-08-01-preview' = {
  name: containerapps_ops_name
  location: location
  identity: {
    type: 'None'
  }
  properties: {
    managedEnvironmentId: managedEnvironments_formula_1_app_env_name_resource.id
    environmentId: managedEnvironments_formula_1_app_env_name_resource.id
    workloadProfileName: 'Consumption'
    configuration: {
      secrets: [
        {
          name: 'reg-pswd-3373ad02-9d67'
        }
      ]
      activeRevisionsMode: 'Single'
      registries: [
        {
          server: 'formula1registry.azurecr.io'
          username: 'formula1registry'
          passwordSecretRef: 'reg-pswd-3373ad02-9d67'
        }
      ]
    }
    template: {
      containers: [
        {
          image: 'formula1registry.azurecr.io/${containerapps_ops_name}:latest'
          name: containerapps_ops_name
          env: [
            {
              name: 'MYSQL_HOST'
              value: 'db'
            }
            {
              name: 'MYSQL_DATABASE'
              value: 'Formula1App_Database'
            }
            {
              name: 'MYSQL_USER'
              value: 'admin'
            }
            {
              name: 'MYSQL_PASSWORD'
              value: 'vDQr62VsmXNV6aMmy'
            }
            {
              name: 'MYSQL_ROOT_PASSWORD'
              value: 'RJvRuyFJLssrJ8jeeDY4'
            }
            {
              name: 'ASPNETCORE_ENVIRONMENT'
              value: 'Production'
            }
            {
              name: 'REDIS_CONNECTIONSTRING'
              value: 'cache:6379'
            }
            {
              name: 'FORCE_DISABLE_HTTPS'
              value: 'true'
            }
            {
              name: 'ASPNETCORE_URLS'
              value: 'https://+:443;http://+:80'
            }
          ]
          resources: {
            // cpu: '0.5'
            memory: '1Gi'
          }
          probes: []
          volumeMounts: [
            {
              volumeName: 'f1appstorageaccount'
              mountPath: '/app/Data'
            }
          ]
        }
      ]
      scale: {
        minReplicas: 0
        maxReplicas: 1
      }
      volumes: [
        {
          name: 'f1appstorageaccount'
          storageType: 'AzureFile'
          storageName: 'f1appstorageaccount'
        }
      ]
    }
  }
}

resource managedEnvironments_formula_1_app_env_name_api_formula1_darrellpoleon_c_formula_240128143608 'Microsoft.App/managedEnvironments/managedCertificates@2023-08-01-preview' = {
  parent: managedEnvironments_formula_1_app_env_name_resource
  name: 'api.formula1.darrellpoleon.c-formula--240128143608'
  location: location
  properties: {
    subjectName: 'api.formula1.darrellpoleon.com'
    domainControlValidation: 'HTTP'
  }
}

resource managedEnvironments_formula_1_app_env_name_api_formula1_darrellpoleon_c_formula_240128165945 'Microsoft.App/managedEnvironments/managedCertificates@2023-08-01-preview' = {
  parent: managedEnvironments_formula_1_app_env_name_resource
  name: 'api.formula1.darrellpoleon.c-formula--240128165945'
  location: location
  properties: {
    subjectName: 'api.formula1.darrellpoleon.com'
    domainControlValidation: 'HTTP'
  }
}

resource managedEnvironments_formula_1_app_env_name_formula1_darrellpoleon_com_formula_240127234324 'Microsoft.App/managedEnvironments/managedCertificates@2023-08-01-preview' = {
  parent: managedEnvironments_formula_1_app_env_name_resource
  name: 'formula1.darrellpoleon.com-formula--240127234324'
  location: location
  properties: {
    subjectName: 'formula1.darrellpoleon.com'
    domainControlValidation: 'HTTP'
  }
}

resource managedEnvironments_formula_1_app_env_name_f1appstorageaccount 'Microsoft.App/managedEnvironments/storages@2023-08-01-preview' = {
  parent: managedEnvironments_formula_1_app_env_name_resource
  name: 'f1appstorageaccount'
  properties: {
    azureFile: {
      accountName: 'f1appstorageaccount'
      shareName: 'formula-1-data'
      accessMode: 'ReadOnly'
    }
  }
}

resource managedEnvironments_formula_1_app_env_name_f1_mysql 'Microsoft.App/managedEnvironments/storages@2023-08-01-preview' = {
  parent: managedEnvironments_formula_1_app_env_name_resource
  name: 'f1-mysql'
  properties: {
    azureFile: {
      accountName: 'f1appstorageaccount'
      shareName: 'f1-mysql'
      accessMode: 'ReadWrite'
    }
  }
}

resource managedEnvironments_formula_1_app_env_name_mysql 'Microsoft.App/managedEnvironments/storages@2023-08-01-preview' = {
  parent: managedEnvironments_formula_1_app_env_name_resource
  name: 'mysql'
  properties: {
    azureFile: {
      accountName: 'f1appstorageaccount'
      shareName: 'mysql'
      accessMode: 'ReadWrite'
    }
  }
}

resource managedEnvironments_formula_1_app_env_name_nginx_conf 'Microsoft.App/managedEnvironments/storages@2023-08-01-preview' = {
  parent: managedEnvironments_formula_1_app_env_name_resource
  name: 'nginx-conf'
  properties: {
    azureFile: {
      accountName: 'f1appstorageaccount'
      shareName: 'nginx-conf'
      accessMode: 'ReadWrite'
    }
  }
}

resource registries_formula1registry_name_repositories_admin 'Microsoft.ContainerRegistry/registries/scopeMaps@2023-11-01-preview' = {
  parent: registries_formula1registry_name_resource
  name: '_repositories_admin'
  properties: {
    description: 'Can perform all read, write and delete operations on the registry'
    actions: [
      'repositories/*/metadata/read'
      'repositories/*/metadata/write'
      'repositories/*/content/read'
      'repositories/*/content/write'
      'repositories/*/content/delete'
    ]
  }
}

resource registries_formula1registry_name_repositories_pull 'Microsoft.ContainerRegistry/registries/scopeMaps@2023-11-01-preview' = {
  parent: registries_formula1registry_name_resource
  name: '_repositories_pull'
  properties: {
    description: 'Can pull any repository of the registry'
    actions: [
      'repositories/*/content/read'
    ]
  }
}

resource registries_formula1registry_name_repositories_pull_metadata_read 'Microsoft.ContainerRegistry/registries/scopeMaps@2023-11-01-preview' = {
  parent: registries_formula1registry_name_resource
  name: '_repositories_pull_metadata_read'
  properties: {
    description: 'Can perform all read operations on the registry'
    actions: [
      'repositories/*/content/read'
      'repositories/*/metadata/read'
    ]
  }
}

resource registries_formula1registry_name_repositories_push 'Microsoft.ContainerRegistry/registries/scopeMaps@2023-11-01-preview' = {
  parent: registries_formula1registry_name_resource
  name: '_repositories_push'
  properties: {
    description: 'Can push to any repository of the registry'
    actions: [
      'repositories/*/content/read'
      'repositories/*/content/write'
    ]
  }
}

resource registries_formula1registry_name_repositories_push_metadata_write 'Microsoft.ContainerRegistry/registries/scopeMaps@2023-11-01-preview' = {
  parent: registries_formula1registry_name_resource
  name: '_repositories_push_metadata_write'
  properties: {
    description: 'Can perform all read and write operations on the registry'
    actions: [
      'repositories/*/metadata/read'
      'repositories/*/metadata/write'
      'repositories/*/content/read'
      'repositories/*/content/write'
    ]
  }
}

resource userAssignedIdentities_formula_1_pipline_uami_name_formula_1_cred 'Microsoft.ManagedIdentity/userAssignedIdentities/federatedIdentityCredentials@2023-07-31-preview' = {
  parent: userAssignedIdentities_formula_1_pipline_uami_name_resource
  name: 'formula-1-cred'
  properties: {
    issuer: 'https://token.actions.githubusercontent.com'
    subject: 'repo:Darrellrp/Formula-1-App:ref:refs/heads/live'
    audiences: [
      'api://AzureADTokenExchange'
    ]
  }
}

resource storageAccounts_f1appstorageaccount_name_default 'Microsoft.Storage/storageAccounts/blobServices@2023-01-01' = {
  parent: storageAccounts_f1appstorageaccount_name_resource
  name: 'default'
  sku: {
    name: 'Standard_LRS'
    // tier: 'Standard'
  }
  properties: {
    cors: {
      corsRules: []
    }
    deleteRetentionPolicy: {
      allowPermanentDelete: false
      enabled: false
    }
  }
}

resource Microsoft_Storage_storageAccounts_fileServices_storageAccounts_f1appstorageaccount_name_default 'Microsoft.Storage/storageAccounts/fileServices@2023-01-01' = {
  parent: storageAccounts_f1appstorageaccount_name_resource
  name: 'default'
  sku: {
    name: 'Standard_LRS'
    // tier: 'Standard'
  }
  properties: {
    protocolSettings: {
      smb: {}
    }
    cors: {
      corsRules: []
    }
    shareDeleteRetentionPolicy: {
      enabled: true
      days: 7
    }
  }
}

resource Microsoft_Storage_storageAccounts_queueServices_storageAccounts_f1appstorageaccount_name_default 'Microsoft.Storage/storageAccounts/queueServices@2023-01-01' = {
  parent: storageAccounts_f1appstorageaccount_name_resource
  name: 'default'
  properties: {
    cors: {
      corsRules: []
    }
  }
}

resource Microsoft_Storage_storageAccounts_tableServices_storageAccounts_f1appstorageaccount_name_default 'Microsoft.Storage/storageAccounts/tableServices@2023-01-01' = {
  parent: storageAccounts_f1appstorageaccount_name_resource
  name: 'default'
  properties: {
    cors: {
      corsRules: []
    }
  }
}

resource containerapps_api_name_resource 'Microsoft.App/containerapps@2023-08-01-preview' = {
  name: containerapps_api_name
  location: location
  identity: {
    type: 'None'
  }
  properties: {
    managedEnvironmentId: managedEnvironments_formula_1_app_env_name_resource.id
    environmentId: managedEnvironments_formula_1_app_env_name_resource.id
    workloadProfileName: 'Consumption'
    configuration: {
      secrets: [
        {
          name: 'formula1registryazurecrio-formula1registry'
        }
      ]
      activeRevisionsMode: 'Single'
      ingress: {
        external: true
        targetPort: 80
        exposedPort: 0
        transport: 'Auto'
        traffic: [
          {
            weight: 100
            latestRevision: true
          }
        ]
        customDomains: [
          {
            name: '${containerapps_api_name}.formula1.darrellpoleon.com'
            certificateId: resourceId('Microsoft.App/managedEnvironments/managedCertificates', managedEnvironments_formula_1_app_env_name, '${containerapps_api_name}.formula1.darrellpoleon.c-formula--240128165945')
            bindingType: 'SniEnabled'
          }
        ]
        allowInsecure: true
        clientCertificateMode: 'Ignore'
        stickySessions: {
          affinity: 'none'
        }
      }
      registries: [
        {
          server: 'formula1registry.azurecr.io'
          username: 'formula1registry'
          passwordSecretRef: 'formula1registryazurecrio-formula1registry'
        }
      ]
    }
    template: {
      containers: [
        {
          image: 'formula1registry.azurecr.io/${containerapps_api_name}:987db7c777557015c52e17917dd8059fe02023d3'
          name: containerapps_api_name
          command: [
            '/bin/sh'
            '-c'
            'dotnet Formula-1-API.dll;'
          ]
          env: [
            {
              name: 'MYSQL_HOST'
              value: 'db'
            }
            {
              name: 'MYSQL_DATABASE'
              value: 'Formula1App_Database'
            }
            {
              name: 'MYSQL_USER'
              value: 'admin'
            }
            {
              name: 'MYSQL_PASSWORD'
              value: 'vDQr62VsmXNV6aMmy'
            }
            {
              name: 'MYSQL_ROOT_PASSWORD'
              value: 'RJvRuyFJLssrJ8jeeDY4'
            }
            {
              name: 'ASPNETCORE_ENVIRONMENT'
              value: 'Production'
            }
            {
              name: 'REDIS_CONNECTIONSTRING'
              value: 'cache:6379'
            }
            {
              name: 'FORCE_DISABLE_HTTPS'
              value: 'true'
            }
            {
              name: 'ASPNETCORE_URLS'
              value: 'https://+:443;http://+:80'
            }
          ]
          resources: {
            // cpu: '0.25'
            memory: '0.5Gi'
          }
          probes: []
        }
      ]
      scale: {
        minReplicas: 0
        maxReplicas: 1
      }
      volumes: [
        {
          name: 'f1appstorageaccount'
          storageType: 'AzureFile'
          storageName: 'f1appstorageaccount'
        }
      ]
    }
  }
  dependsOn: [

    managedEnvironments_formula_1_app_env_name_api_formula1_darrellpoleon_c_formula_240128165945
  ]
}

resource containerapps_web_name_resource 'Microsoft.App/containerapps@2023-08-01-preview' = {
  name: containerapps_web_name
  location: location
  identity: {
    type: 'None'
  }
  properties: {
    managedEnvironmentId: managedEnvironments_formula_1_app_env_name_resource.id
    environmentId: managedEnvironments_formula_1_app_env_name_resource.id
    workloadProfileName: 'Consumption'
    configuration: {
      secrets: [
        {
          name: 'formula1registryazurecrio-formula1registry'
        }
      ]
      activeRevisionsMode: 'Single'
      ingress: {
        external: true
        targetPort: 80
        exposedPort: 0
        transport: 'Auto'
        traffic: [
          {
            weight: 100
            latestRevision: true
          }
        ]
        customDomains: [
          {
            name: 'formula1.darrellpoleon.com'
            certificateId: managedEnvironments_formula_1_app_env_name_formula1_darrellpoleon_com_formula_240127234324.id
            bindingType: 'SniEnabled'
          }
        ]
        allowInsecure: true
        clientCertificateMode: 'Ignore'
        stickySessions: {
          affinity: 'none'
        }
      }
      registries: [
        {
          server: 'formula1registry.azurecr.io'
          username: 'formula1registry'
          passwordSecretRef: 'formula1registryazurecrio-formula1registry'
        }
      ]
    }
    template: {
      containers: [
        {
          image: 'formula1registry.azurecr.io/${containerapps_web_name}:dc054c92bc256a1b9fbd0d41d1a765a655a48bf0'
          name: containerapps_web_name
          env: [
            {
              name: 'NGINX_PORT'
              value: '80'
            }
          ]
          resources: {
            // cpu: '0.5'
            memory: '1Gi'
          }
          probes: []
          volumeMounts: [
            {
              volumeName: 'nginx-conf'
              mountPath: '/etc/nginx/conf.d/'
            }
          ]
        }
      ]
      scale: {
        minReplicas: 0
        maxReplicas: 1
      }
      volumes: [
        {
          name: 'nginx-conf'
          storageType: 'AzureFile'
          storageName: 'nginx-conf'
        }
      ]
    }
  }
}

resource storageAccounts_f1appstorageaccount_name_default_f1_mysql 'Microsoft.Storage/storageAccounts/fileServices/shares@2023-01-01' = {
  parent: Microsoft_Storage_storageAccounts_fileServices_storageAccounts_f1appstorageaccount_name_default
  name: 'f1-mysql'
  properties: {
    accessTier: 'TransactionOptimized'
    shareQuota: 5120
    enabledProtocols: 'SMB'
  }
  dependsOn: [

    storageAccounts_f1appstorageaccount_name_resource
  ]
}

resource storageAccounts_f1appstorageaccount_name_default_formula_1_data 'Microsoft.Storage/storageAccounts/fileServices/shares@2023-01-01' = {
  parent: Microsoft_Storage_storageAccounts_fileServices_storageAccounts_f1appstorageaccount_name_default
  name: 'formula-1-data'
  properties: {
    accessTier: 'TransactionOptimized'
    shareQuota: 5120
    enabledProtocols: 'SMB'
  }
  dependsOn: [

    storageAccounts_f1appstorageaccount_name_resource
  ]
}

resource storageAccounts_f1appstorageaccount_name_default_nginx_conf 'Microsoft.Storage/storageAccounts/fileServices/shares@2023-01-01' = {
  parent: Microsoft_Storage_storageAccounts_fileServices_storageAccounts_f1appstorageaccount_name_default
  name: 'nginx-conf'
  properties: {
    accessTier: 'TransactionOptimized'
    shareQuota: 5120
    enabledProtocols: 'SMB'
  }
  dependsOn: [

    storageAccounts_f1appstorageaccount_name_resource
  ]
}
