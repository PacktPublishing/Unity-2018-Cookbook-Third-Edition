# Unity-2018-Cookbook-Third-Edition
Unity 2018 Cookbook, Third Edition, published by Packt
# Book Name

<!--
![GitHub Logo](/images/cover.png)
-->

<a href="https://www.packtpub.com/game-development/unity-2018-cookbook-third-edition"><img src="/images/cover.png" alt="Unity 2018 Cookbook" height="256px" align="right"></a>

This is the code repository for [Unity 2018 Cookbook](https://www.packtpub.com/game-development/unity-2018-cookbook-third-edition), published by Packt.

**Over 160 recipes to take your 2D and 3D game and virtual reality development to the next level**

## What is this book about?
With the help of the Unity 2018 Cookbook, you’ll discover how to make the most of the UI system, learn to work with external resources and files, and understand how to animate both 2D and 3D characters and game scene objects using Unity's Mecanim animation toolsets.

This book covers the following exciting features: 
* Get creative with Unity’s shaders and learn to build your own shaders with the new Shader Graph tool
* Create a text and image character dialog with the free Fungus Unity plugin
* Explore new features integrated into Unity 2018, including TextMesh Pro and ProBuilder
* Master Unity audio, including ducking, reverbing, and matching pitch to animation speeds
* Work with the new Cinemachine and timeline to intelligently control camera movements

If you feel this book is for you, get your [copy](https://www.amazon.com/dp/1788471903) today!

<a href="https://www.packtpub.com/?utm_source=github&utm_medium=banner&utm_campaign=GitHubBanner"><img src="https://raw.githubusercontent.com/PacktPublishing/GitHub/master/GitHub.png" 
alt="https://www.packtpub.com/" border="5" /></a>


## Instructions and Navigations
All of the code is organized into folders. For example, Chapter01.

The code will look like the following:
```
using UnityEngine; 
using System.Collections; 

public class ScrollZ : MonoBehaviour { 
  public float scrollSpeed = 20; 

  void Update () { 
    Vector3 pos = transform.position; 
    Vector3 localVectorUp = transform.TransformDirection(0,1,0); 
    pos += localVectorUp * scrollSpeed * Time.deltaTime; 
    transform.position = pos; 
  } 
} 
```

**Following is what you need for this book:**
Copy and paste the Audience section from the EPIC.

With the following software and hardware list you can run all code files present in the book (Chapter 1-15).

### Software and Hardware List

| Chapter  | Software required                   | OS required                        |
| -------- | ------------------------------------| -----------------------------------|
| 1-4,6-19 | Unity 2018.1 or later               | Windows, Mac OS X (Any) |
| 5        | Unity 2018.1 or lagter +            |                                    |
|          | an image editing application        |                                    |
|          | such as GIMP                        | Windows, Mac OS X (Any) |



We also provide a PDF file that has color images of the screenshots/diagrams used in this book. [Click here to download it](Graphics Bundle Link).

### Related products <Other books you may enjoy>
* Unity 2018 By Example - Second Edition [[Packt]](https://www.packtpub.com/game-development/unity-2018-example-second-edition?utm_source=github&utm_medium=repository&utm_campaign=9781788398701) [[Amazon]](https://www.amazon.com/dp/178839870X)

* Unity 2018 Augmented Reality Projects [[Packt]](https://www.packtpub.com/game-development/unity-2018-augmented-reality-projects?utm_source=github&utm_medium=repository&utm_campaign=9781788838764) [[Amazon]](https://www.amazon.com/dp/1788838769)

## Get to Know the Author
[**Matt Smith**](https://github.com/dr-matt-smith)
is a computing academic at what will soon become the Technological University of Dublin, Ireland.

Matt started computer programming on a brand new ZX80 and submitted 2 games for his computing O-level exam. After nearly 10 years as a full-time student on a succession of scholarships, he gained several degrees in computing, including a PhD in computational musicology.

In 1985 Matt wrote the lyrics, and was in the band (and sang, sorry about that by the way) whose music appeared on the B-side of the audio cassette carrying the computer game Confuzion. Matt is a documentation author for the open source Fungus Unity project.

With his children he studies and teaches Taekwon-Do, and all three of them are beginning guitar lessons in 2018.



### Suggestions and Feedback
[Click here](https://docs.google.com/forms/d/e/1FAIpQLSdy7dATC6QmEL81FIUuymZ0Wy9vH1jHkvpY57OiMeKGqib_Ow/viewform) if you have any feedback or suggestions.
