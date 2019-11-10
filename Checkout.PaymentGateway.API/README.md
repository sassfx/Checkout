## Checkout Payment Gateway

This is a basic implementation of a payment gateway to illustrate how this service might be structured.

The system is designed following CQRS and the mediator pattern (implemented using the _MediatR_ library).

Two routes are exposed:

- GET _payments/{paymentId}_ : this returns information about a the payment referred to by the GUID payment id.
- POST _payment_ : this takes a JSON body and creates a payment from it

In order to use the app, just launch it with IIS express (I haven't yet configured a more sophisticated build/release pipeline) and use something like postman to access the REST endpoints.

The app assumes that storing in memory is fine and that a simple interface for communicating with the bank will do for now.

Ideally I would expose swagger endpoints for both of these routes, but I was having some issues with Swashbuckle and .NET Core 3.

Also, using a mediator allows us to easily wrap the command/query/request handlers with decorators to add logging, instrumentation and error handling. These would probably be the next things I'd waork on (particularly the error handling).
