1. Add Bicep templates to ./infra
2. Create Azure service principal; add command output to AZURE_CREDENTIALS repository secret
    az ad sp create-for-rbac --name demo-hungry-square-gh --role contributor --scopes /subscriptions/1edcae36-b0ca-4eb6-bf76-e2ae5aea6a35 --sdk-auth
3. Add CI and teardown GitHub workflows
4. Activate Unity license https://game.ci/docs/github/activation