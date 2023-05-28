# iXtensions

### Documentação do iXtension
#### Visão Geral
A biblioteca iXtension é um conjunto de extensões para o C# que fornecem recursos adicionais e funcionalidades úteis. Este repositório do GitHub contém o código-fonte e a documentação para facilitar o uso e a contribuição.

#### Instalação
Você pode instalar o iXtension através do NuGet. Utilize o seguinte comando no console do NuGet para instalar a biblioteca:

##### NuGet
```
Install-Package iXtension 
```

##### .NET CLI
```
dotnet add package iXtension 
```

#### Recursos Principais
O iXtension oferece os seguintes recursos principais:

##### Extensões de String
 - `ToInteger()`: Converte um string para um inteiro.
 - `ToTitleCase()`: Converte uma string para o formato "Title Case".
 - `RemoveWhitespace()`: Remove todos os espaços em branco de uma string.
 - `RemoveLast(int lenght = 1)`: Remove os ultimos caracteres.
 - `RemoveLastIfValuesIs(int removeLenght, string valueToVerifyAndRemove)`: Remove os ultimos caracteres se forem iguais a <b>valueToVerifyAndRemove</b>.
 - `LastLenghtIs(string compare)`: Verifica se o ultimo valor de uma string é igual a **compare**.
 - `MultContains(string[] values)`: Verifica se a coleção de **values** posui o string que está sendo verificado.
 - `ToFirstUpper()`: Converte a primeira letra de uma string em letra maiuscula.
 - `ToCamelCase()`: Converte toda primeira letra de uma palavra em Maiuscula. _OBS. As palavras são separadas por expaços_


##### Extensões de Coleções
 - Shuffle(): Embaralha os elementos de uma coleção.
 - IsNullOrEmpty(): Verifica se uma coleção está nula ou vazia.
 - GetRandomElement(): Retorna um elemento aleatório de uma coleção.

##### Extensões de DateTime
 - ToUnixTimestamp(): Converte um objeto DateTime em um carimbo de data/hora UNIX.
 - IsWeekend(): Verifica se uma data é um final de semana.
 - IsLeapYear(): Verifica se um ano é bissexto.
...
