"use strict";
//Iteration 1, ask alexa "What is the status of my application?" and have alexa respond from a fixed value.
//Iteration 2, ask alexa "What is the status of my application?" and have alexa respond from a chosen value based on simple condition.
//Iteration 3, ask alexa "What is the status of my application?" and have alexa respond with a question for more information, then give a value;
//Iteration 4, ask alexa "What is the status of my application?" and have alexa find a value from an external database and report that value.

var Alexa = require("alexa-sdk");

var handlers = {

  "LaunchRequest": function () {
  
  //  this.attributes.applications = {
    //'status': 'Incomplete'
    //},

    this.response.speak("Hello, What would you like to know about your Connector Application?"); 
    this.emit(':responseReady');
  }


  'StatusIntent' : function () {
    //var currentStatus = this.attributes.applications.status;
      
    this.response.speak("Your application is incomplete" );//+ currentStatus +"."); 
    //this.response.speak("Your application is Pending, but scheduled for review tomorrow. Check again in a couple days!"); 
    this.emit(':responseReady');
  },
 


exports.handler = function(event, context, callback){
  var alexa = Alexa.handler(event, context, callback);

  //alexa.dynamoDBTableName = 'connectrApplicationsTest';
    alexa.registerHandlers(handlers);
    alexa.execute();
};