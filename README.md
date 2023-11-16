# FEMSA_TesteDB
Cadastro de Motorista usando ASP.NET C# e Crud em Procedure SQL<br>

Para criação das Tabelas e procedures executar script TesteDB.sql<br>

Apos rodar o script TesteDB.sql entre com as configurações:<br>

Configura o banco de dados no arquivo Web.config, conforme seu banco:<br>

```
<connectionStrings>
    <add name="FEMSA" connectionString="DefaultConnection": "Data Source = localhost; Initial Catalog = Seguro; Uid = sa; Password = 1234; MultipleActiveResultSets=true; Pooling=true; Min Pool Size=0; Max Pool Size=250; Connect Timeout=30;" providerName="System.Data.SqlClient" />      
</connectionStrings>
```

