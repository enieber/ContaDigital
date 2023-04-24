# ContaDigital

> ` Projeto desenvolvido em C# dontnet core 6 `
> ` Banco de dado Mysql `
> ` Conexão via Dapper `

# Prerando Ambiente

<p>Executar script create_database_tables.sql no diretrio ´API\API\Scripts´
 <p>Instalar versão dotnet core6.1
<p> retore das dependencias dos projetos
<p> apontar no arquivo .env a conexão do banco mysql

> ` Uso da API`

<p> Metodo para criar usuário e conta: /v1/user
<p>![image](https://user-images.githubusercontent.com/59657083/234091697-c0628297-4d07-43d8-8b68-54d80cb77ee8.png)

<p> response com dados de usuario e conta.
<p>![image](https://user-images.githubusercontent.com/59657083/234091855-6b1bf2bc-f676-428d-9fb0-75c2d6c934ca.png)

<p> Metodo para autenticar usuário: /authenticate
<p>![image](https://user-images.githubusercontent.com/59657083/234092153-f7f0d9ff-3eaf-45f6-a3bc-15dfb9b22943.png)

<p> response com token.
<p>![image](https://user-images.githubusercontent.com/59657083/234092207-f1a9d91b-0b72-4c7c-9faf-ae2531fa6052.png)

<p> Metodo para consultar dados do usuário: /v1/user/getaccountbycpf
<p>![image](https://user-images.githubusercontent.com/59657083/234092374-5a06bd33-62d6-43f5-93c3-de547a50d32c.png)

<p> response com informações do usuário/conta.
<p>![image](https://user-images.githubusercontent.com/59657083/234092565-24fa92ce-c5b7-4110-92d6-ccb84662736d.png)

<p> Metodo para consultar tipos de transações /v1/typeTransaction
<p>![image](https://user-images.githubusercontent.com/59657083/234092758-afd7f16a-0f40-44a4-a87e-b59f56adae02.png)

<p> Metodo para gerar transações /v1/accountMov
<p>![image](https://user-images.githubusercontent.com/59657083/234093210-b40c55a1-e11d-4db8-a4a0-206a8fae03a6.png)

<p> response da transação.
<p>![image](https://user-images.githubusercontent.com/59657083/234093297-07f65733-4693-4708-9280-21815b457105.png)

<p> Metodo para consultar extrato /v1/accountMov/accountid
<p>![image](https://user-images.githubusercontent.com/59657083/234093519-cda0f9fe-a713-412a-aa80-68c041992fb6.png)

<p> response da consulta
<p>![image](https://user-images.githubusercontent.com/59657083/234093596-e1d6149c-d245-4f1b-af94-238cf3d04e97.png)

<p> Metodo para consultar detalhes de uma transação /v1/accountMov/id
<p>![image](https://user-images.githubusercontent.com/59657083/234093827-453d36d2-4642-436c-9d86-307062b58b85.png)

<p> response da consulta
<p>![image](https://user-images.githubusercontent.com/59657083/234093861-98c7b69f-10cc-4690-935d-65ae872e503c.png)









