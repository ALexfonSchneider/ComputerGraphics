#pragma once
#include <iostream>
#include <array>
#include <random>
#include <glut.h>

using namespace std;

enum class RubicCubeElementColors {
	red,
	orange,
	white,
	yellow,
	blue,
	green,
};

class Color {
public:
	int red, green, blue;

	Color(int red, int green, int blue) {
		this->red = red;
		this->green = green;
		this->blue = blue;
	}

	Color() : Color(0, 0, 0) {}
};

enum Position {
	left,
	right,
	buttom,
	top,
	forword,
	beheind,
};

struct Sides {
	Color* left = nullptr;
	Color* right = nullptr;
	Color* buttom = nullptr;
	Color* top = nullptr;
	Color* forword = nullptr;
	Color* beheind = nullptr;
};

class RubicCubeElement {
	Sides* sides = nullptr;

public:
	RubicCubeElement() {
		sides = new Sides();
	}

	RubicCubeElement(Sides* side) {
		this->sides = side;
	}

	void SetColor(Position pos, Color* color) {
		if (pos == Position::left) {
			sides->left = color;
		}
		else if (pos == Position::right) {
			sides->right = color;
		}
		else if (pos == Position::buttom) {
			sides->buttom = color;
		}
		else if (pos == Position::top) {
			sides->top = color;
		}
		else if (pos == Position::forword) {
			sides->forword = color;
		}
		else if (pos == Position::beheind) {
			sides->beheind = color;
		}
	}

	// поворот на плоскости X0Y
	void rotateXOY()
	{
		auto temp = sides->right;
		sides->right = sides->beheind;
		sides->beheind = sides->left;
		sides->left = sides->forword;
		sides->forword = temp;
	}

	// поворот на плоскости X0Z
	void rotateYOZ()
	{
		auto temp = sides->forword;
		sides->forword = sides->buttom;
		sides->buttom = sides->beheind;
		sides->beheind = sides->top;
		sides->top = temp;
	}

	// поворот на плоскости Y0Z
	void rotateXOZ()
	{
		auto temp = sides->top;
		sides->top = sides->left;
		sides->left = sides->buttom;
		sides->buttom = sides->right;
		sides->right = temp;
	}
};

class RubicCube {
	struct {
		Color* red = new Color(255, 0, 0);
		Color* green = new Color(0, 255, 0);
		Color* blue = new Color(0, 0, 255);
		Color* white = new Color(0, 0, 0);
		Color* yellow = new Color(255, 255, 0);
		Color* orange = new Color(255, 165, 0);
	};

	array<int, 6> angle;
	double size = 3;
public:
	vector<array<RubicCubeElement*, 9>> elements; // XY layers

	RubicCube(int size) {
		this->size = size;

		for (int i = 0; i < 3; i++) {
			elements.push_back(array<RubicCubeElement*, 9>());
			for (int j = 0; j < 9; j++) {
				elements[i].at(j) = new RubicCubeElement();
			}
		}

		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 9; j++) {
				if (j < 3) {
					elements[i][j]->SetColor(Position::forword, white);
				}
				if (j >= 6) {
					elements[i][j]->SetColor(Position::beheind, yellow);
				}
				if (j % 3 == 2) {
					elements[i][j]->SetColor(Position::right, red);
				}
				if (j % 3 == 0) {
					elements[i][j]->SetColor(Position::left, orange);
				}
				if (i == 0) {
					elements[i][j]->SetColor(Position::buttom, green);
				}
				if (i == 2) {
					elements[i][j]->SetColor(Position::top, blue);
				}
			}
		}
	}
};