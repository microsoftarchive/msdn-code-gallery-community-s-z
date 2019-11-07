# Sample for Testing AngularJS App via Protractor in Visual Studio Node.js Project
## Requires
- Visual Studio 2013
## License
- MS-LPL
## Technologies
- ASP.NET
- AngularJS
- Protractor
- Node.js
- Nancy
- Selenium
- WebDriver
## Topics
- Web App End-to-end Testing
- Writing Protractor Tests in Visual Studio
- Automated Testing
## Updated
- 02/19/2014
## Description

<h1><span style="font-size:large">
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">describe('angularjs homepage', function() {
  it('should greet the named user', function() {
    browser.get('http://localhost:12116/');
    element(by.model('yourName')).sendKeys('Julie');
    var greeting = element(by.binding('yourName'));
    expect(greeting.getText()).toEqual('Hello Julie!');
  });
  describe('todo list', function() {
    var todoList;
    beforeEach(function() {
      browser.get('http://localhost:12116/');
      todoList = element.all(by.repeater('todo in todos'));
    });
    it('should list todos', function() {
      expect(todoList.count()).toEqual(2);
      expect(todoList.get(1).getText()).toEqual('build an angular app');
    });
    it('should add a todo', function() {
      var addTodo = element(by.model('todoText'));
      var addButton = element(by.css('[value=&quot;add&quot;]'));
      addTodo.sendKeys('write a protractor test');
      addButton.click();
      expect(todoList.count()).toEqual(3);
      expect(todoList.get(2).getText()).toEqual('write a protractor test');
    });
  });
});
</pre>
<div class="preview">
<pre class="js">describe(<span class="js__string">'angularjs&nbsp;homepage'</span>,&nbsp;<span class="js__operator">function</span>()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;it(<span class="js__string">'should&nbsp;greet&nbsp;the&nbsp;named&nbsp;user'</span>,&nbsp;<span class="js__operator">function</span>()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;browser.get(<span class="js__string">'http://localhost:12116/'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;element(by.model(<span class="js__string">'yourName'</span>)).sendKeys(<span class="js__string">'Julie'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;greeting&nbsp;=&nbsp;element(by.binding(<span class="js__string">'yourName'</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;expect(greeting.getText()).toEqual(<span class="js__string">'Hello&nbsp;Julie!'</span>);&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;describe(<span class="js__string">'todo&nbsp;list'</span>,&nbsp;<span class="js__operator">function</span>()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;todoList;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;beforeEach(<span class="js__operator">function</span>()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;browser.get(<span class="js__string">'http://localhost:12116/'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;todoList&nbsp;=&nbsp;element.all(by.repeater(<span class="js__string">'todo&nbsp;in&nbsp;todos'</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;it(<span class="js__string">'should&nbsp;list&nbsp;todos'</span>,&nbsp;<span class="js__operator">function</span>()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;expect(todoList.count()).toEqual(<span class="js__num">2</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;expect(todoList.get(<span class="js__num">1</span>).getText()).toEqual(<span class="js__string">'build&nbsp;an&nbsp;angular&nbsp;app'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;it(<span class="js__string">'should&nbsp;add&nbsp;a&nbsp;todo'</span>,&nbsp;<span class="js__operator">function</span>()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;addTodo&nbsp;=&nbsp;element(by.model(<span class="js__string">'todoText'</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;addButton&nbsp;=&nbsp;element(by.css(<span class="js__string">'[value=&quot;add&quot;]'</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;addTodo.sendKeys(<span class="js__string">'write&nbsp;a&nbsp;protractor&nbsp;test'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;addButton.click();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;expect(todoList.count()).toEqual(<span class="js__num">3</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;expect(todoList.get(<span class="js__num">2</span>).getText()).toEqual(<span class="js__string">'write&nbsp;a&nbsp;protractor&nbsp;test'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
<span class="js__brace">}</span>);&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
&nbsp;</div>
Introduction</span></h1>
<p><span style="font-size:small">That is a sample of the Protractor (<a href="https://github.com/angular/protractor">https://github.com/angular/protractor</a>)&nbsp;test spec which tests web application built with AngularJS (<a href="http://angularjs.org/">http://angularjs.org</a>).
 As you can tell, AngularJS is getting more and more popular in ASP.NET applications. It would be really nice to have a unified environment to develop apps as well as write tests. Yes, we want get them done in Visual Studio.&nbsp;It is good to learn and use
 end-to-end testing framework like Protractor. But we sometime get hold back by tooling.</span></p>
<p><span style="font-size:small">There is some chanllenge in setting up Protractor with Visual Studio. Thanks to Node.js Tool for Visual Studio makes it possible to do so.</span></p>
<p><span style="font-size:small">This sample contains two projects. One simple web app project that under test and a protractor test project that contains the test cases.</span><em><br>
</em></p>
<h1><span style="font-size:large">Building the Sample</span></h1>
<p><span style="font-size:small">Getting web application up and running is straight forward. NuGet will pull the necessary dependencies to build the web application.</span></p>
<p><span style="font-size:small">Get Visual Studio to load node.js project you need to install Node.js Tool for Visual Studio first. You can get it from here
<a href="https://nodejstools.codeplex.com/releases/view/116275">https://nodejstools.codeplex.com/releases/view/116275</a></span></p>
<p><span style="font-size:small"><span style="font-size:small">After you load the Node.js project. Follow the steps below to run the&nbsp;tests.</span></span></p>
<p><span style="font-size:small"><span style="font-size:small"><em>Before continuing, make sure you</em></span></span></p>
<ul>
<li><span style="font-size:small"><span style="font-size:small"><em>have </em><em>installed
</em><em>Node.js, required to install packages and run tests</em></span></span> </li><li><span style="font-size:small"><span style="font-size:small"><em>have configured JDK., required to run selenium standalone server<br>
</em></span></span></li></ul>
<h2><span style="font-size:small">Setup</span></h2>
<ul>
<li><span style="font-size:small">Open cmd line and go to project folder (which contains `package.json`)</span>
</li><li><span style="font-size:small">Execute `npm install` to install protractor</span>
</li><li><span style="font-size:small">Execute `node_modules\.bin\webdriver-manager update` to install chrome webdriver and selenium standalone server</span>
</li></ul>
<h2><span style="font-size:small">Running Test</span></h2>
<h4><span style="font-size:small">run test via chromedriver directly</span></h4>
<p><span style="font-size:small">Execute `node_modules\.bin\protractor chromeOnlyConf.js` to run the test. Which launches a chrome instance and run the test against it.</span></p>
<p><span style="font-size:small">This is what you expect to see. It tells you all three test cases are successful.</span></p>
<pre><span style="font-size:small">&nbsp;&nbsp;&nbsp; ...</span></pre>
<pre><span style="font-size:small">&nbsp;&nbsp;&nbsp; Finished in 11.95 seconds<br>&nbsp;&nbsp;&nbsp; 3 tests, 5 assertions, 0 failures</span></pre>
<h4><span style="font-size:small">run test via selenium standalone server</span></h4>
<ul>
<li><span style="font-size:small">Execute `node_modules\.bin\webdriver-manager start` to start the server</span>
</li><li><span style="font-size:small">Execute `node_modules\.bin\protractor conf.js` to run the tests</span>
</li></ul>
<p><span style="font-size:small">You will expect the same result as running against chromedriver.
<br>
</span></p>
<ul>
</ul>
<h1><span style="font-size:large">More Information</span></h1>
<p><span style="font-size:small">If you would like to read more on Protractor. Feel free to read my blog posts. Hope you will find something useful.</span></p>
<ul>
<li><span style="font-size:small"><a href="http://wp.me/p1vM0R-5D">AngularJS, Protractor, Visual Studio! SUPER DRY!!</a></span>
</li></ul>
