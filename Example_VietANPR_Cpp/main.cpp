// Example_VietANPR_Cpp.cpp : This file contains the 'main' function. Program execution begins and ends there.
//
#pragma once
#include <iostream>
#include "VietANPR.h"


int main(int argc, char** argv)
{
    VietANPR* vietanpr = new VietANPR();

    Plate result = vietanpr->Read("2019-03-25.06-12-14.jpg");    

    std::cout << result.text << std::endl;

    return 0;
}