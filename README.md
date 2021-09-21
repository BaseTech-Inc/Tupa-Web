<div align="center">
<img align="center" width="24%" src="./.github/logo.png" />
<br>
<i>
    Página Web da empresa Tupã
</i>
</div>

## Ajustes e melhorias

O projeto ainda está em desenvolvimento e as próximas atualizações serão voltadas nas seguintes tarefas:

- [ ] Login/Register
- [ ] Mapa
- [ ] Locais
    - [ ] Mais pesquisados
    - [ ] Histórico
- [ ] Dashboard
    - [ ] Forecast
    - [ ] Alertas
    - [ ] Gráfico
- [ ] Configurações de Usuário

## Começando

### Instalando localmente projeto

```bash
# Clone o repositório em sua máquina
$ git clone https://github.com/BaseTech-Inc/Tupa-Web.git
```

### Configurando ambiente

- Para inicializar os [valores secretos](https://docs.microsoft.com/pt-br/visualstudio/ide/how-to-add-app-config-file?view=vs-2019) é nescessário criar o arquivo `secrets.xml` dentro da pasta `App_Data`.

    É nescessário inserir os seguindes valores:

    ```xml
    <?xml version="1.0" encoding="utf-8" ?>

    <root>
      <secrets ver="1.0">
        <secret name="client_secret" value="client_secret" />
      </secrets>
    </root>
    ```

<img src="https://github.githubassets.com/images/mona-whisper.gif" align="right" />

## Licença

Esse projeto está sob licença. Veja o arquivo [`LICENÇA`](https://github.com/BaseTech-Inc/Tupa-Web/blob/master/LICENSE) para mais detalhes.