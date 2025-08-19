# Refit Worker Bridge

### 📌 Descrição do Projeto:

Este projeto tem como finalidade explorar diferentes formas de realizar requisições HTTP a uma API externa. Para isso, será utilizada a JsonPlaceholder, uma Fake API bastante utilizada em testes de requests.

A aplicação irá consumir os dados da API através de diferentes bibliotecas e recursos do .NET (Refit, RestSharp e HttpClient) e, em seguida, persistir as informações recebidas em uma API própria.

Além disso, os endereços retornados pela JsonPlaceholder serão validados por meio da API geocodemaps.co, verificando se as coordenadas associadas são válidas. Caso não sejam, será realizada uma busca para determinar quais coordenadas corretas correspondem ao endereço informado.

O fluxo será orquestrado por meio de Worker Services, garantindo a execução contínua das tarefas em segundo plano, e Quartz.NET, que permitirá a criação, individualização de jobs e agendamento para cada etapa do processo.

![GitHub repo size](https://img.shields.io/github/repo-size/iuricode/README-template?style=for-the-badge)
![GitHub language count](https://img.shields.io/github/languages/count/iuricode/README-template?style=for-the-badge)
![GitHub forks](https://img.shields.io/github/forks/iuricode/README-template?style=for-the-badge)
![Bitbucket open issues](https://img.shields.io/bitbucket/issues/iuricode/README-template?style=for-the-badge)
![Bitbucket open pull requests](https://img.shields.io/bitbucket/pr-raw/iuricode/README-template?style=for-the-badge)

<img src="imagem.png" alt="Exemplo imagem">

### 🎯 Objetivos

1- Testar diferentes formas de consumo de API: Comparar Refit, RestSharp e HttpClient.

2- Persistir dados consumidos: Armazenar o retorno da API externa em uma API interna.

3- Validar endereços: Consultar a API geocodemaps.co para validar se os endereços possuem coordenadas válidas.

4- Corrigir coordenadas inválidas: Caso o retorno da JsonPlaceholder contenha coordenadas incorretas, utilizar a API de geocodificação para corrigir.

5- Avaliar desempenho: Futuramente, realizar testes de performance entre as diferentes abordagens de consumo de API.

6- Organizar e agendar processos: Utilizar Quartz.NET para individualizar os jobs e garantir maior controle sobre o fluxo.

7- Automatizar execução: Manter o fluxo ativo com Worker Services, rodando em background.

> Linha adicional de texto informativo sobre o que o projeto faz. Sua introdução deve ter cerca de 2 ou 3 linhas. Não exagere, as pessoas não vão ler.

### Ajustes e melhorias

O projeto ainda está em desenvolvimento e as próximas atualizações serão voltadas para as seguintes tarefas:

- [x] Tarefa 1
- [x] Tarefa 2
- [x] Tarefa 3
- [ ] Tarefa 4
- [ ] Tarefa 5

## 💻 Pré-requisitos

Antes de começar, verifique se você atendeu aos seguintes requisitos:

- Você instalou a versão mais recente de `<linguagem / dependência / requeridos>`
- Você tem uma máquina `<Windows / Linux / Mac>`. Indique qual sistema operacional é compatível / não compatível.
- Você leu `<guia / link / documentação_relacionada_ao_projeto>`.

## 🚀 Instalando <nome_do_projeto>

Para instalar o <nome_do_projeto>, siga estas etapas:

Linux e macOS:

```
<comando_de_instalação>
```

Windows:

```
<comando_de_instalação>
```

## ☕ Usando <nome_do_projeto>

Para usar <nome_do_projeto>, siga estas etapas:

```
<exemplo_de_uso>
```

Adicione comandos de execução e exemplos que você acha que os usuários acharão úteis. Forneça uma referência de opções para pontos de bônus!

## 📫 Contribuindo para <nome_do_projeto>

Para contribuir com <nome_do_projeto>, siga estas etapas:

1. Bifurque este repositório.
2. Crie um branch: `git checkout -b <nome_branch>`.
3. Faça suas alterações e confirme-as: `git commit -m '<mensagem_commit>'`
4. Envie para o branch original: `git push origin <nome_do_projeto> / <local>`
5. Crie a solicitação de pull.

Como alternativa, consulte a documentação do GitHub em [como criar uma solicitação pull](https://help.github.com/en/github/collaborating-with-issues-and-pull-requests/creating-a-pull-request).

## 🤝 Colaboradores

Agradecemos às seguintes pessoas que contribuíram para este projeto:

<table>
  <tr>
    <td align="center">
      <a href="#" title="defina o título do link">
        <img src="https://avatars3.githubusercontent.com/u/69026547" width="100px;" alt="Foto do Matheus no GitHub"/><br>
        <sub>
          <b>Matheus Knaul</b>
        </sub>
      </a>
    </td>
    <td align="center">
      <a href="#" title="defina o título do link">
        <img src="https://s2.glbimg.com/FUcw2usZfSTL6yCCGj3L3v3SpJ8=/smart/e.glbimg.com/og/ed/f/original/2019/04/25/zuckerberg_podcast.jpg" width="100px;" alt="Foto do Mark Zuckerberg"/><br>
        <sub>
          <b>Mark Zuckerberg</b>
        </sub>
      </a>
    </td>
  </tr>
</table>

## 😄 Seja um dos contribuidores

Quer fazer parte desse projeto? Clique [AQUI](CONTRIBUTING.md) e leia como contribuir.

## 📝 Licença

Esse projeto está sob licença. Veja o arquivo [LICENÇA](LICENSE.md) para mais detalhes.