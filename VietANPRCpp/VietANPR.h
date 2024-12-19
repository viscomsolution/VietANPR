#ifndef VIETANPR_H
#define VIETANPR_H

#pragma once
#include <iostream>
#include <vector>

#include "Plate.h"
#include "opencv2/core.hpp"

#ifdef VIETANPR_EXPORTS
#define VIETANPR_API __declspec(dllexport)
#else
#define VIETANPR_API __declspec(dllimport)
#endif

class VIETANPR_API VietANPR
{
    std::string input;
    
public:
    VietANPR();
    ~VietANPR();

    std::vector<Plate> Reads(std::string imagePath);
    std::vector<Plate> Reads(cv::Mat frame);

    Plate Read(std::string imagePath);
    Plate Read(cv::Mat frame);
};

#endif // VIETANPR_H
