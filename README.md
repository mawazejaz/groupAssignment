# Lecture 1
# ==================

# devops-aspnet-core-github-workflow-v2a
Repository for Dev Ops Class 

# About the class 
MS DevOPS RIU @ 14.Mar.2023

# Prerequisits
Create an account on GItHub
Create a Repository (Public with Readme File)
Edit the redme file and commit the code via click action

Install VS Code   (https://code.visualstudio.com/docs/?dv=win)
Install Git (https://git-scm.com/)
Install .NET 6.0 (https://dotnet.microsoft.com/en-us/download)

# Topics to Cover

Git Pull / Push

VS Code

Branching

I am chinging this manuscript V2.0


# Commands to Execute

mkdir MyFirstAzureWebApp

code MyFirstAzureWebApp

dotnet new webapp -f net6.0

dotnet run --urls=https://localhost:5001/

git add .

git commit -am "Version 1.0 aspnet core web app added"

git push

git pull

# Branching
Create a branch
=====================
git branch <new-branch> 
git branch feature01_inprogress_branch 

git branch <new-branch> <base-branch>
git branch feature01_1_inprogress_branch  feature01_inprogress_branch 

Switch to another branch
======================
git checkout feature01_inprogress_branch


# Gitflow Workflow Demonstration
Link 1: https://www.atlassian.com/git/tutorials/using-branches/git-checkout#:~:text=New%20Branches&text=The%20git%20branch%20command%20can,to%20switch%20to%20that%20branch.

link2: https://endjin.com/blog/2013/04/a-step-by-step-guide-to-using-gitflow-with-teamcity-part-3-gitflow-commands 

link3: http://danielkummer.github.io/git-flow-cheatsheet/

git flow init
>> Branch name for production releases: [main] main
>> Branch name for "next release" develop

git flow feature start f001 
git flow feature start f002


git flow feature finish f001
git flow feature publish f002

# Lecture 2
# ==================
# Set up Secrets in GitHub Action workflows 

[GitHub Secrets](https://help.github.com/en/actions/automating-your-workflow-with-github-actions/creating-and-using-encrypted-secrets) are encrypted and allow you to store sensitive information, such as access tokens, in your repository.

You could use GitHub secrets to store your Azure Credentials, Publish profile of your Web app, container registry credentials or any such sensitive details which are required to automate your CI/CD workflows using GitHub Actions. 

## Creating secrets

1. On GitHub, navigate to the main page of the repository.
1. Under your repository name, click on the "Settings" tab.
1. In the left sidebar, click Secrets.
1. On the right bar, click on "Add a new secret"
   ![](images/create-secret.png)
1. Type a name for your secret in the "Name" input box.
1. Type the value for your secret.
1. Click Add secret.
   ![](images/Add-secret-name-value.png)
   
   
## Consume secrets in your workflow

To consume a secret within an action workflow, set the secret as an input or environment variable in your workflow. 
Review the action's README file to learn about which inputs and environment variables the action expects. 
For example, most of the [Azure actions](https://github.com/Azure/actions) would need AZURE_CREDENTIALS to be set as a secret.
For more information, see ["Workflow syntax for GitHub Actions."](https://help.github.com/en/articles/workflow-syntax-for-github-actions/#jobsjob_idstepsenv)

```yaml  
steps:
  - name: Sample Azure action
    with: # Set Azure credentials secret as an input
      credentials: ${{ secrets.AZURE_CREDENTIALS }}
    env: # Or as an environment variable
      credentials: ${{ secrets.AZURE_CREDENTIALS }}
```
   
## Set secret with Azure Credentials

Most of the Azure services use user-level Azure credentials i.e., Azure Service Principal for deployments. 

Follow the steps to create the Azure credentials (Service Principal) :
    * Run the below [az cli](https://docs.microsoft.com/en-us/cli/azure/?view=azure-cli-latest) command 
```bash  

   az ad sp create-for-rbac --name "myApp" --role contributor \
                            --scopes /subscriptions/{subscription-id}/resourceGroups/{resource-group} \
                            --sdk-auth
                            
  # Replace {subscription-id}, {resource-group} with the subscription, resource group details

  # The command should output a JSON object similar to this:

  {
    "clientId": "<GUID>",
    "clientSecret": "<GUID>",
    "subscriptionId": "<GUID>",
    "tenantId": "<GUID>",
    (...)
  }
  
```
  * Store the above JSON as the value of a GitHub secret with a name, for example 'AZURE_CREDENTIALS'
  * Now in the workflow file in your branch: `.github/workflows/workflow.yml` replace the secret in Azure login action with your secret name

## Set secret with Web App Publish_Profile

**Note: As of October 2020, Linux web apps will need the app setting `WEBSITE_WEBDEPLOY_USE_SCM` set to `true` before downloading the publish profile from the Azure portal. This requirement will be removed in the future.**
1. In the Azure portal, Navigate to your web app
1. In the Overview page of the app, click on "Get publish profile". A publish profile is a kind of deployment credential, useful when you don't own the Azure subscription. 
1. Open the downloaded settings file in VS Code and copy the contents of the file.
1. Create a new secret in your GitHub repo using the copied contents of the publish profile.

   ![](images/get-publish-profile.png)
   
   # ======================
   az ad sp create-for-rbac --name "myApp" --role contributor \
                            --scopes /subscriptions/{subscription-id}/resourceGroups/{resource-group} \
                            --sdk-auth


az ad sp create-for-rbac --name "webapp-demo-riu-ms2023-v001" --role contributor  --scopes /subscriptions/0ff3b063-e340-4ba3-b4bf-935dcfe0e9fc/resourceGroups/webapp-demo-riu-ms2023-v001_group --sdk-auth


{
  "clientId": "-f8db-4db7-a549-d8f773236ae5",
  "clientSecret": "HTJRO1WgBmTzHKSpR4xchY3K4D~50c-a",
  "subscriptionId": "-e340-4ba3-b4bf-935dcfe0e9fc",
  "tenantId": "-f3ca-4e81-b7e3-319f0b105009",
  "activeDirectoryEndpointUrl": "https://login.microsoftonline.com",
  "resourceManagerEndpointUrl": "https://management.azure.com/",
  "activeDirectoryGraphResourceId": "https://graph.windows.net/",
  "sqlManagementEndpointUrl": "https://management.core.windows.net:8443/",
  "galleryEndpointUrl": "https://gallery.azure.com/",
  "managementEndpointUrl": "https://management.core.windows.net/"
}

# ===========================
Create an example workflow in GitHub
   
In your repository, create the . github/workflows/ directory to store your workflow files.
   
In the . github/workflows/ directory, create a new file called learn-github-actions. yml and add the following code. ...
   
Commit these changes and push them to your GitHub repository.
