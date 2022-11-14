#include <iostream>
#include <random>
#include <glut.h>
#include "Rubik's Cube.h"

//https://www.youtube.com/watch?v=R1v7IN4Q3EA&ab_channel=Anton

using namespace std;

void init();
void display();
void resize(int width, int height);
void key(unsigned char key, int x, int y);
void idle();

//float t = 0;
//float dt = 0.1;
//bool rotate_ = false;

float t = 0;
float dt = 0.1;

RubicCube cube(3);

int main(int argc, char** argv) {
	glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
	glutInitWindowSize(240, 240);
	glutCreateWindow("test window");
	glClearColor(1.0, 1.0, 1.0, 1.0);
	glutDisplayFunc(display);
	glutIdleFunc(idle);
	glutMainLoop();


}

void display() {
	/*glClear(GL_COLOR_BUFFER_BIT);


	glFlush();*/
}

void idle() {
	t += dt;
	glutPostRedisplay();
}