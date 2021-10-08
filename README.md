<div align="center">
<img align="center" width="24%" src="./.github/logo.png" />
<br>
<i>
    P�gina Web da empresa Tup�
</i>
</div>

## Ajustes e melhorias

O projeto ainda est� em desenvolvimento e as pr�ximas atualiza��es ser�o voltadas nas seguintes tarefas:

- [x] Login/Register
- [ ] Mapa
- [ ] Locais
    - [ ] Mais pesquisados
    - [ ] Hist�rico
- [ ] Dashboard
    - [X] Forecast
    - [X] Alertas
    - [ ] Gr�fico
- [ ] Configura��es de Usu�rio
    - [X] Editar Info
        - [X] Alterar Nome
        - [X] Alterar Senha
        - [X] Deletar Conta
    - [ ] Tema
    - [X] Planos
    - [ ] Notifica��es

## Come�ando

### Instalando localmente projeto

```bash
# Clone o reposit�rio em sua m�quina
$ git clone https://github.com/BaseTech-Inc/Tupa-Web.git
```

### Configurando ambiente

- Para inicializar os [valores secretos](https://docs.microsoft.com/pt-br/visualstudio/ide/how-to-add-app-config-file?view=vs-2019) � nescess�rio criar o arquivo `secrets.xml` dentro da pasta `App_Data` (�s vezes pode ser nescess�rio apagar a pasta `App_Data` e recri�-la).

    � nescess�rio inserir os seguindes valores, dentro do arquivo `secrets.xml`:

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

    Para gerar o `client_id` e o `client_secret` � necess�rio [criar projeto do Console de APIs Google](https://developers.google.com/workspace/guides/create-project).

<img src="https://github.githubassets.com/images/mona-whisper.gif" align="right" />

## Licen�a

Esse projeto est� sob licen�a. Veja o arquivo [`LICEN�A`](https://github.com/BaseTech-Inc/Tupa-Web/blob/master/LICENSE) para mais detalhes.