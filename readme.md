# Sefer.Backend.Pdf.Api
This compact web service is designed to convert HTML documents into PDF format specifically for the Sefer Framework. 
The library utilizes the shared configuration mechanism to load its settings, ensuring a centralized and consistent 
configuration management approach. It is programmed to retrieve the ApiKey from the configuration, which serves as a 
critical authentication token for API interactions. Consequently, this ApiKey must be included in all incoming 
requests to the API to ensure secure and authorized access.

## Configuration

The web service necessitates the configuration of the following (environment) variables:

| Configuration Key | Environment Var | Description                                                           |
|-------------------|-----------------|-----------------------------------------------------------------------|
| Pdf.ApiKey        | PDF_API_KEY     | This API key will be used by your clients connecting with the service |