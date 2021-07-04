Serialização (C#) 
</h3>

<blockquote align="center">“A serialização é o processo de converter um objeto em um fluxo de bytes para armazenar o objeto ou transmiti-lo para a memória, 
um banco de dados ou um arquivo. Sua finalidade principal é salvar o estado de um objeto para recriá-lo quando necessário. 
O processo inverso é chamado desserialização”</blockquote>


## :rocket: Como a serialização funciona:

Esta ilustração mostra o processo geral de serialização:

<img src="img/serializaçao.PNG">

O objeto é serializado para um fluxo que transporta os dados. O fluxo também pode ter informações sobre o tipo do objeto, como sua versão, cultura e nome do assembly. 
A partir desse fluxo, o objeto pode ser armazenado em um banco de dados, em um arquivo ou em uma memória.

## Usos para serialização:

A serialização permite que o desenvolvedor salve o estado de um objeto e recrie-o conforme necessário, 
fornecendo armazenamento de objetos, bem como troca de dados. Por meio da serialização, um desenvolvedor pode executar ações como:
<br>

* Enviando o objeto para um aplicativo remoto usando um serviço Web.

* Passando um objeto de um domínio para outro.

* Passando um objeto por meio de um firewall como uma cadeia de caracteres JSON ou XML.

* Manter informações específicas de segurança ou de usuário entre aplicativos.


## Serialização JSON

<p>O System.Text.Json namespace contém classes para serialização e desserialização de JavaScript Object Notation (JSON). JSON é um padrão aberto que normalmente é usado para compartilhar dados na Web.</p>

<p>A serialização JSON serializa as propriedades públicas de um objeto em uma cadeia de caracteres, matriz de bytes ou fluxo que está em conformidade com a especificação JSON RFC 8259. Para controlar a maneira de JsonSerializer serializar ou desserializar uma instância da classe:<p/>

* Usar um JsonSerializerOptions objeto.

* Aplicar atributos do System.Text.Json.Serialization namespace a classes ou propriedades.

* Implementar conversores personalizados.


## Serialização XML e binária

<p>O System.Runtime.Serialization namespace contém classes para serialização e desserialização binária e XML.</p>

<p>A serialização binária usa a codificação binária para produzir uma serialização compacta para usos como armazenamento ou fluxos de rede com base em soquete. Na serialização binária, todos os membros, mesmo aqueles que são somente leitura, são serializados e o desempenho é aprimorado.</p>

<p>A serialização XML serializa as propriedades e os campos públicos de um objeto, ou os parâmetros e os valores de retorno de métodos, em um fluxo XML que esteja de acordo com um documento XSD (linguagem de definição de esquema XML) específico. A serialização XML resulta em classes fortemente tipadas com propriedades e campos públicos que são convertidos em XML. System.Xml.Serializationcontém classes para serialização e desserialização de XML. Aplique atributos a classes e a membros de classe para controlar a maneira como o XmlSerializer serializa ou desserializa uma instância da classe.</p>






