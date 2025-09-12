# Azure Full stack

# Hosting in Azure
    az webapp up --name my-own-supersimple-weather-app -g test1 --location westeurope --sku B1 --os-type linux
    az webapp config appsettings set --name my-own-supersimple-weather-app --resource-group test1 --settings APPINSIGHTS_INSTRUMENTATIONKEY=$(az monitor app-insights component show --app myappinsights --resource-group test1 --query instrumentationKey -o tsv) APPLICATIONINSIGHTS_CONNECTION_STRING=$(az monitor app-insights component show --app myappinsights --resource-group test1 --query connectionString -o tsv) ApplicationInsightsAgent_EXTENSION_VERSION=~3