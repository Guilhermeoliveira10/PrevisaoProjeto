# 📊 Projeto Previsão com ASP.NET Core + ML.NET

Este projeto tem como objetivo demonstrar a aplicação prática de Machine Learning utilizando o framework ASP.NET Core Web API com a biblioteca **ML.NET**, realizando uma **previsão binária** com base em dados fornecidos em formato `.csv`. O algoritmo utilizado foi o **FastTree**, com uma divisão dos dados em **70% para treino** e **30% para teste**.

---

## 🎯 Funcionalidade

A API realiza a previsão se um cliente comprará ou não um produto com base em dois atributos:

- **Idade**
- **Salário**

---

## 🧠 Algoritmo

- **ML.NET** com algoritmo de classificação: `FastTree`
- Separação de dados: `70% treino / 30% teste`
- Métrica de avaliação exibida no console: **Acurácia**

---

## 📁 Estrutura da Solução

(estrutura já exibida no código acima)

---

## 📊 Dataset

O arquivo `dados.csv` contém três colunas e está localizado na pasta `Data/`:

```
Idade,Salario,Comprou
25,3000,true
40,7000,false
...
```

---

## 🧪 Exemplo de Requisição

### Método: `POST /previsao`
#### Corpo da Requisição:

```json
{
  "idade": 30,
  "salario": 4500
}
```

#### Resposta Esperada:

```json
{
  "predicao": true,
  "probabilidade": 0.8432,
  "score": 0.6721
}
```

---

## 🚀 Como Executar o Projeto

1. Clone o repositório:
```bash
git clone https://github.com/Guilhermeoliveira10/PrevisaoProjeto.git
cd PrevisaoProjeto
```

2. Restaure os pacotes:
```bash
dotnet restore
```

3. Execute a aplicação:
```bash
dotnet run
```

4. Acesse o Swagger:
```
https://localhost:xxxx/swagger
```

---

## 👥 Integrantes

- Luiz Alecsander Viana - RM553034  
- Guilherme Augusto de Oliveira - RM554176  
- Lucas Martinez Lopes - RM553816  

---

## 📹 Demonstração em Vídeo

🔗 [Clique aqui para assistir ao vídeo de execução da aplicação](https://youtu.be/hDgWt3sSugs)

---

## 📦 Tecnologias Utilizadas

- ASP.NET Core Web API (.NET 6)
- ML.NET
- FastTree Classifier
- Swagger (Swashbuckle.AspNetCore)

---

## 📌 Observações

- Validações de entrada com `DataAnnotations`
- Arquitetura simples em camadas (DTO, Controller, Service, Model)
- Projeto com objetivo acadêmico para avaliação de conceitos de IA com .NET
