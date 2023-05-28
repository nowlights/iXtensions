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


### Uso Básico
Aqui estão alguns exemplos de como usar as extensões do iXtension em seu código C#:

#### Extensões de String
```C#
using iXtension;

string myString = "Hello, World!";
string removeWhiteSpace = myString.RemoveWhiteSpace(); // Resultado: "Hello,World!"

string removeLast = myString.RemoveLast(): // Resultado: "Hello, World";
string removeLastIfValueIs = myString.RemoveLastIfvalueIs(1, "!"); // Resultado: "Hello, World";

string stringWithoutWhitespace = myString.RemoveWhitespace(); // Resultado: "Hello,World!"
```

### Contribuição
Contribuições para o iXtension são bem-vindas! Se você gostaria de melhorar o projeto ou adicionar novas extensões, siga as etapas a seguir:

1. Faça um fork deste repositório.
2. Crie um branch para sua nova funcionalidade (git checkout -b nova-funcionalidade).
3. Faça as alterações necessárias e adicione novas extensões.
4. Faça commit das suas alterações (git commit -m "Adiciona nova funcionalidade").
5. Faça push para o branch (git push origin nova-funcionalidade).
6. Abra uma pull request neste repositório.


### Licença
O iXtension é distribuído sob a licença MIT. Para mais informações, consulte o arquivo LICENSE.
