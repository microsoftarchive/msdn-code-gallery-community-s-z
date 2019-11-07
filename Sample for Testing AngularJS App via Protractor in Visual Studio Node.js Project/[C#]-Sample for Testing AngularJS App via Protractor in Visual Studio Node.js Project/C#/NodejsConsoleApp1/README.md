# Protractor with Visual Studio

## Setup
 - Open cmd line and go to project folder (which contains `package.json`)
 - Execute `npm install` to install protractor
 - Execute `node_modules\.bin\webdriver-manager update` to install chrome webdriver and selenium standalone server

## Running Test

### run test via chromedriver directly
Execute `node_modules\.bin\protractor chromeOnlyConf.js` to run the test. Which launches a chrome instance and run the test against it.

This is what you expect to see. It tells you all three test cases are successful.

    ...

    Finished in 11.95 seconds
    3 tests, 5 assertions, 0 failures

### run test via selenium standalone server
 - Execute `node_modules\.bin\webdriver-manager start` to start the server
 - Execute `node_modules\.bin\protractor conf.js` to run the tests

You will expect the same result as running against chromedriver.

Further reading if you are interested in getting more on using protractor

 - [AngularJS, Protractor, Visual Studio! SUPER DRY!!](http://wp.me/p1vM0R-5D)
 - [This is How I Structure Protractor Tests in Visual Studio, Part 1](http://wp.me/p1vM0R-6s)
 - [This is How I Structure Protractor Tests in Visual Studio, Part 2](http://wp.me/p1vM0R-6E)

