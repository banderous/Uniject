Uniject
=======

Uniject, the Testability framework for Unity3D

* Plain Old C Sharp, testable MonoBehaviour equivalents
* Unit test your code outside of Unity
* A robust and flexible way of creating GameObjects automatically, by inference of the code that drives them
* Constructors!
* An extremely flexible code base – in short, the benefits of DI + IOC.

Uniject comes integrated into a sample Unity project.

The code under test is a very simple mono behaviour equivalent that has a Sphere collider and a rigid body. When its transform falls below a threshold value, it resets it to the origin.

The project has a unit test that verifies this behaviour, and a sample scene that spawns an instance of it.

<dl>
  <dt>To build and run the Unit tests (OSX)</dt>
</dl>

Run BUILD.sh

<dl>
  <dt>To run the example scene</dt>
</dl>

Open the project in Unity and load the 'example' scene.

<a href="http://outlinegames.com/2012/08/29/on-testability/">Read on</a>