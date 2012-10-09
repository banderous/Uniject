Uniject
=======

Uniject, the Testability framework for Unity3D

* Plain Old C Sharp, testable MonoBehaviour equivalents
* Unit test your code outside of Unity
* A robust and flexible way of creating GameObjects automatically, by inference of the code that drives them
* Constructors!
* An extremely flexible code base – in short, the benefits of DI + IOC.

<dl>
  <dt>Where to start</dt>
</dl>

This project contains a sample Unity project configured for Uniject.

The code under test is a very simple mono behaviour equivalent that has a Sphere collider and a rigid body. When its transform falls below a threshold value, it resets it to the origin.

The project has a unit test that verifies this behaviour, and a sample scene that spawns an instance of it.

1. To run the unit tests

Open the MonoDevelop project at src/test/Test.sln

The project is setup to reference the projects that Unity automatically generates, and has its own C Sharp project containing the unit tests.

2. To run the example scene

Open the project in Unity and load the 'example' scene.

<a href="http://outlinegames.com/2012/08/29/on-testability/">Read on</a>