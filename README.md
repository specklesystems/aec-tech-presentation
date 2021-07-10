# AEC Tech Speckle Repo

This repo contains all code and files related to Speckle's demo on AEC Tech 2021.

> If you are new to Speckle you may also find these links handy:
>
> - **Docs**: [Speckle.guide](https://speckle.guide)
> - **Community**: [Speckle.community](https://speckle.community)
> - **Public server**: [Speckle.xyz](https://speckle.xyz)

It is comprised of 3 different starter projects:

## WebStarter

> You can check it out live [HERE](https://specklesystems.github.io/aec-tech-presentation/WebStarter/index.html)

This is the main demo app we built to demonstrate how to build simple websites that interact with Speckle, and provides the boilerplate code to get you started on querying the Speckle API and using our viewer `npm` package.

In order to keep things simple, it's a pure `html/js/css` library.

All dependencies are directly referenced on the `html` file. You'll also find a simple `styles.css` that depends on [Bulma.io](https://bulma.io) for quick styling.

`app.js` is the main `js` module for the page. It contains all the button interactions, viewer creation, etc...

`speckleQueries.js` and `speckleUtils.js` contain all the "Speckle specific" functions to interact with the API.

## CSharpStarter and PythonStarter

These two are secondary projects we added just in case `javascript` was not your favorite programming language 😅. In this case we tried to keep things simple.

These 2 projects are just boilerplate code (also heavily documented) for a data processing script.

Both scripts perform exactly the same steps (with minor differences in the code):

- Use your machine's local accounts
- Authenticate to the XYZ server
- Receive some data from the `main` branch of a stream
- Send some data to a different branch in the same stream

> These scripts could be run dependent on `webhooks` or `graphql subscriptions`, allowing to react to changes, process data in whatever way you need, and save the results back.
> We'll leave that part to the hackers! But we're happy to answer questions and guide you through. Just ping us at [speckle.community](https://speckle.community)
