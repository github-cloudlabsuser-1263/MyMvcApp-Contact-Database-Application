# MyMvcApp-Contact-Database-Application

This is an ASP.NET Core MVC CRUD application for managing contacts. The project demonstrates basic Create, Read, Update, and Delete operations using an in-memory list.

## Features

- List all users/contacts
- Search users by name or email
- View user details
- Create new users
- Edit existing users
- Delete users

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Azure CLI](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli)
- An Azure subscription

## Running Locally

1. Clone the repository.
2. Navigate to the project directory:
    ```sh
    cd MyMvcApp-Contact-Database-Application
    ```
3. Run the application:
    ```sh
    dotnet run
    ```
4. Open your browser and go to `https://localhost:5001` or the URL shown in the terminal.

## Deployment to Azure

This project includes an ARM template and a parameter file for easy deployment to Azure App Service.

### Steps

1. **Login to Azure:**
    ```sh
    az login
    ```

2. **Set your subscription (if needed):**
    ```sh
    az account set --subscription "<your-subscription-id>"
    ```

3. **Create a resource group (if it doesn't exist):**
    ```sh
    az group create --name <your-resource-group> --location <location>
    ```

4. **Deploy the ARM template:**
    ```sh
    az deployment group create \
      --resource-group <your-resource-group> \
      --template-file deploy.json \
      --parameters @deploy.parameters.json
    ```

5. **Build and publish your app locally:**
    ```sh
    dotnet publish -c Release
    ```

6. **Deploy to Azure using the Azure CLI:**
    ```sh
    az webapp deploy \
      --resource-group <your-resource-group> \
      --name <your-webapp-name> \
      --src-path ./bin/Release/net8.0/publish
    ```
    Replace `<your-webapp-name>` with the value you set in `deploy.parameters.json`.

7. **Access your app:**

    After deployment, your app will be available at the Azure App Service URL.

## Notes

- The current implementation uses an in-memory list for storing users. For production, integrate with a persistent database (e.g., Azure SQL Database).
- Update the ARM template and parameters as needed for your environment.

## License

MIT