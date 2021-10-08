<div align="center">
<img align="center" width="24%" src="./.github/logo.png" />
<br>
<i>
    Página Web da empresa Tupã
</i>
</div>

## Ajustes e melhorias

O projeto ainda está em desenvolvimento e as próximas atualizações serão voltadas nas seguintes tarefas:

- [x] Login/Register
- [ ] Mapa
- [ ] Locais
    - [ ] Mais pesquisados
    - [ ] Histórico
- [ ] Dashboard
    - [X] Forecast
    - [X] Alertas
    - [ ] Gráfico
- [ ] Configurações de Usuário
    - [X] Editar Info
        - [X] Alterar Nome
        - [X] Alterar Senha
        - [X] Deletar Conta
    - [ ] Tema
    - [X] Planos
    - [ ] Notificações

## Começando

### Instalando localmente projeto

```bash
# Clone o repositório em sua máquina
$ git clone https://github.com/BaseTech-Inc/Tupa-Web.git
```

### Configurando ambiente

- Para inicializar os [valores secretos](https://docs.microsoft.com/pt-br/visualstudio/ide/how-to-add-app-config-file?view=vs-2019) é nescessário criar o arquivo `secrets.xml` dentro da pasta `App_Data` (às vezes pode ser nescessário apagar a pasta `App_Data` e recriá-la).

    É nescessário inserir os seguindes valores, dentro do arquivo `secrets.xml`:

    ```xml
    <?xml version="1.0" encoding="utf-8" ?>

    <root>
      <secrets ver="1.0">
        <secret name="client_id" value="client_id" />
        <secret name="client_secret" value="client_secret" />
        <secret name="redirect_uri" value="redirect_uri" />
        <secret name="base_url_server" value="base_url_server" />
      </secrets>
    </root>
    ```

    Para gerar o `client_id` e o `client_secret` é necessário [criar projeto do Console de APIs Google](https://developers.google.com/workspace/guides/create-project).

<img src="https://github.githubassets.com/images/mona-whisper.gif" align="right" />

## Licença

Esse projeto está sob licença. Veja o arquivo [`LICENÇA`](https://github.com/BaseTech-Inc/Tupa-Web/blob/master/LICENSE) para mais detalhes.