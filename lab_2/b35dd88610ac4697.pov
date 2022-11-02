#include "colors.inc"

background { color rgb <0.5,0.5,1> }
camera
{
 location<0,18,-22>
 look_at<0,10,0>
 //rotate y* 180
            
}

light_source
{
 <1,1,0>*100 color White
}  
 
plane
{
 <0,1,0> 1
  pigment{color MediumWood }
} 


#declare f4 = 
union
{

#declare f1 = 
merge
{
 difference
 {
      cylinder
      {
       <0,3,0><0,3,-4>2
       texture{ pigment{color Gray  }}
      }
      cylinder
      {
       <1,2.3,1><1,2.3,-5>2
       texture{ pigment{color Gray  }}
      }
      box
      {
       <-0.95,3,-4><0,0,0>
       texture{ pigment{color Gray  }}
      } 
  
 }
}
  
#declare f2 = 
merge
{
 difference
 {
      cylinder
      {
       <0,3,0><0,3,-5>2
       texture{ pigment{color Gray }}
      }
      cylinder
      {
       <1,2.3,1><1,2.3,-6>2
       texture{ pigment{color Gray  }}
      }
      box
      {
       <-0.95,3,-5><0,0,0>
       texture{ pigment{color Gray }}
      } 
  
 }
 rotate y *180  
} 
 
 
union
{
difference
{
    box
    {
     <8,8,3><-8,16,0>                                                                     
     pigment{rgb<0.2,0.2,0.2>} 
     finish{ambient 0.5} 
    } 
    box
    {
     <4,13.5,3.2><-4,10.5,-3> 
     texture{ pigment{color Gray  }}
    } 
     
     object {f1 translate<-7,11.8,3.2>}
     
     object {f2 translate<7,11.8,-0.3> }  
    box
    {
    <6,15,0.1><-6,9,-0>
    pigment{rgb<0.1,0.1,0.1>} 
    } 
    box
    {
    <6,16.1,1.8><-6,15.8,0.8> 
 
    }
    cylinder
    {
     <7,15,3.1><7,15,-0.2> 0.3
      pigment{color Gray }    
    }
}
box
{
 <4,13.5,3.2><-4,10.5,-0.1> 
 texture{ pigment{color Yellow filter 0.8 }}
} 

box
{
<6,15.9,1.8><-6,14,0.8> 
pigment{Brown}
}
 
cylinder
{
 <-7,15,3.1><-7,15,-0.2> 0.3     
}
 
cylinder
{
 <-7,8.5,3.1><-7,8.5,-0.2> 0.3     
} 


 

 
difference
{

    cylinder
    {
       <4,12,2.9><4,12,0.1> 2.5
      finish{ambient 0.5} 
    }
     
    cylinder
    
    {
       <4,12,3.02><4,12,-0.02> 1
       pigment{White}
    }

} 

difference
{
    cylinder
    {
       <-4,12,2.9><-4,12,0.1> 2.5
       finish{ambient 0.5}
    }
      cylinder
    {
       <-4,12,3.02><-4,12,-0.02> 1
       pigment{White}
    }
} 

} 
}

object{f4 translate<0,-7,0>}