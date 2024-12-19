#pragma once
#include <vector>

class Plate
{
	int m_width, m_height;
public:

	static enum PlateType
	{
		Unknown = 0,
		Long,
		Short
	};
	
	PlateType type;


	std::string text = "";
	std::string alphanumeric = "";
	float score = -1.0;
	bool isValid = false;
};

