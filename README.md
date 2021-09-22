# finbuckle-multiple-spa-issue-sample

Use the following commands to create databases. We are using LocalDb for development, you can update it to whatever server you are using.
```
Update-Database -Context ApplicationDbContext
Update-Database -Context MultiTenantStoreDbContext
```

If you update data source, don't forgot to update the **ApplicationDbContextFactory**

```
npm install 
```
run the command inside ClientApp / admin and ClientApp / user


To allow subdomains in the development mode, you need to update the applicationhost which you can find under **{solution folder}\.vs\SpaApplication.MultiTenant\config\applicationhost**. Open the file and find for entry `<binding protocol="https" bindingInformation="*:44343:localhost" />` below this line, add the following lines to use subdomains for this project.
```
<binding protocol="https" bindingInformation="*:44343:idsa.localhost" />
<binding protocol="https" bindingInformation="*:44343:contoso.localhost" />
<binding protocol="https" bindingInformation="*:44343:kiqbal.localhost" />
```

Now, you can use any subdomain listed above to test the app. **Don't forget to open visual studio as admin**
