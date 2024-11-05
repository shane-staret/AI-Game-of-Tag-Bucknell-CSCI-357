#  Team Tag Final Project

## Project Description
#### The primary idea behind this project is to train at least two AI’s through machine learning to play tag against one another. These AI agents will be playing in a finite 3d space containing obstacles. To accomplish this, Unity is being used along with the ML-Agents library included within Unity. This library makes use of Tensorflow to build and train intelligent agent models.

## Getting the Code Running
#### 

Below are detailed instructions for building this project yourself. Some software required to build this project are not included in the gitlab repository for file size reasons, and some steps will rely on downloads from other sources.

- Install Unity 2020.3.1.1 on your local machine
    - Downloads for specific Unity versions can be found [here](https://unity3d.com/get-unity/download/archive)
- Install Python version 3.7.8 on your machine
    - Other versions of Python may also work, but this project was specifically built with Python 3.7.8
- Create a new blank Unity project 
- This project requires installation of the ML-Agents Unity package. Install the ML-Agents package in your blank Unity project.
    - This project was built with ML-Agents release 17, although later releases may still work
    - A link to the ML-Agents github can be found [here](https://github.com/Unity-Technologies/ml-agents)
    - Instructions for setting up ML-Agents on your machine can be found [here](https://github.com/Unity-Technologies/ml-agents/blob/release_17_docs/docs/Installation.md)
        - Ensure that you have set up the python environment as detailed in the ML-Agents documentation, as none of the python libraries are included on our gitlab repository
- Once ML-Agents is installed in your blank Unity project, download the contents of this gitlab repository, and drag them into the folder for your Unity project. 
    - This will overwrite some files, allow them to be overwritten
    - For safety purposes, close the blank Unity project before copying these files over
    - An example of what a Unity project folder looks like can be seen below

![Image of folders](https://i.imgur.com/gCAGfr1.png)

- Upon opening the Unity project, all of this projects assets and scripts should now be visible in the asset browser
- You may now run our training environment by entering your python virtual environment and entering the ‘mlagents-learn --force’ command
    - Details about running an ML-Agents environment can be found [here](https://github.com/Unity-Technologies/ml-agents/blob/release_17_docs/docs/Getting-Started.md)


## Important Documents
#### *  [GEA Worksheet](https://gitlab.bucknell.edu/krd008/csci357_finalproject/blob/master/docs/GEA.pdf)
#### *  [User Manual](https://gitlab.bucknell.edu/krd008/csci357_finalproject/blob/master/docs/User_Manual.pdf)
#### *  [Medium Article](https://medium.com/@shanestaret/a-game-of-tag-using-ai-90bfd0f10008)
#### *  [Final Report](https://gitlab.bucknell.edu/krd008/csci357_finalproject/blob/master/docs/CogSci_Final_Research_Paper.pdf)
