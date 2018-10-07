/*******************************************************
*    Problem Name:  
*    Problem ID:    
*    Occassion:    _ Contest _ _ _
*
*    Algorithm:      
*    Special Case:    
*    Judge Status:    
*    Author:        Atiqur Rahman
*******************************************************/
//#include <iostream>
#include <cstdio>
#include <cstring>
//#include <new>
//#include <vector>
//#include <queue>
//#include <map>
//#include <algorithm>
//#include <iomanip>//for cout formatting
//#define  INF 2147483648
//#define EPS 1e-8
using namespace std;

class BigInt{
#define MAX(a,b)  ((a>b)?a:b)
    char *operand;
    bool sign;
public:
  BigInt(){

    operand=new char[2];
    strcpy(operand,"0");
      sign=0;
  }
  BigInt(int size){
  
    operand=new char[size+1];
    strcpy(operand,"0");
    sign=0;
    
  }
  BigInt(char ch[]){
  
      operand=new char[strlen(ch)+1];
      int i,j=0;
      sign=0;
      
      for(i=strlen(ch)-1;i>0;i--)
        operand[j++]=ch[i];
      if(ch[0]=='-')
        sign=1;
      else operand[j++]=ch[0];

      operand[j]=NULL;  
  }
  bool isGreater(char op1[],char op2[]){
  
  
    int len1=strlen(op1),len2=strlen(op2),i;
    if(len1<len2)  return false;
    
    if(len1==len2){

      for(i=len1-1;i>=0;i--)
        if(op1[i]<op2[i])
          return false;
        else if(op1[i]>op2[i]) return true;
    }
    return true;
  }
  bool isAbsZero(){

    int i;
    for(i=strlen(operand)-1;i>=0;i--)
      if(operand[i]!='0') return false;
    return true;
  }
  void absAdd(char op1[],char op2[],char res[]){
  
      int i,len1=strlen(op1),len2=strlen(op2),car=0,data1,data2,sum;
      for(i=0;i<len1||i<len2||car;i++){
      
        data1=data2=0;
        if(i<len1)  data1=op1[i]-48;
        if(i<len2)  data2=op2[i]-48;

        sum=data1+data2+car;
        res[i]=sum%10+48;
        car=sum/10;      
      }
      res[i]=NULL;
  }
  void absSub(char op1[],char op2[],char res[]){
  
      int i,len1=strlen(op1),len2=strlen(op2),car=0,data1,data2,sum;
      for(i=0;i<len1||i<len2||car;i++){
      
        data1=data2=0;
        if(i<len1)  data1=op1[i]-48;
        if(i<len2)  data2=op2[i]-48;
        
        sum=data1-data2-car;
        if(sum<0){
          sum+=10;
          car=1;
        }
        else car=0;            
        res[i]=sum+48;  
      }
      res[i]=NULL;
  }
  void absDiv(char op1[],char op2[],BigInt &res,BigInt &rem){
  
      int len1=strlen(op1),len2=strlen(op2),i,len3=len1,resDigit;
      res.operand[len1]=rem.operand[len3]=NULL;
      for(i=len1-1;i>=0;i--){
      
        rem.operand[i]=op1[i];
        
        resDigit=0;
        while(isGreater(&rem.operand[i],op2)){
        
          absSub(&rem.operand[i],op2,&rem.operand[i]);
          resDigit++;
          if(len3>1&&rem.operand[len3-1]=='0')          
            rem.operand[--len3]=NULL;
          
        }
        if(len3>1&&rem.operand[len3-1]=='0')          
            rem.operand[--len3]=NULL;
        res.operand[i]=resDigit+48;
      
      }
      
  
  }
  BigInt operator+(BigInt obj2){
  
    
      BigInt res(2+MAX(strlen(operand),strlen(obj2.operand)));
      if(sign==obj2.sign)
        res.sign=sign;
      if(sign^obj2.sign&&isGreater(operand,obj2.operand)){
      
        absSub(operand,obj2.operand,res.operand);
        res.sign=sign;
      }
      else if(sign^obj2.sign){
      
        absSub(obj2.operand,operand,res.operand);
        res.sign=obj2.sign;
      }
      else
        absAdd(operand,obj2.operand,res.operand);
      
    return res;
  }
  BigInt operator-(BigInt obj2){
  
    obj2.sign=(obj2.sign==true)?false:true;     

    return (*this+obj2);
  }
  BigInt operator*(BigInt obj2){
  
      BigInt res(2+strlen(operand)+strlen(obj2.operand));
      if(sign^obj2.sign)
        res.sign=true;

      int len3=0,car,data1,data2,j,i,len2=strlen(obj2.operand),sum,len1=strlen(operand);
      for(i=0;i<len2;i++){
      
        car=0;
        data2=obj2.operand[i]-48;
        for(j=0;j<len1||car;j++){
        
          data1=(j<len1)?operand[j]-48:0;
          sum=data1*data2+car;
          sum+=(i+j>=len3)?0:res.operand[i+j]-48;
          car=sum/10;
          res.operand[i+j]=sum%10+48;          
        }
        len3=i+j;
      }
      res.operand[len3]=NULL;
      return res;
  }
  BigInt operator/(BigInt obj2){
  
      int l=strlen(operand);
      BigInt res(l+2),rem(l+2);

      if(sign^obj2.sign)
        res.sign=true;
      absDiv(operand,obj2.operand,res,rem);
    return res;
  
  }
  BigInt operator%(BigInt obj2){
  
      int l=strlen(operand);
      BigInt res(l+2),rem(l+2);

      absDiv(operand,obj2.operand,res,rem);
      if(sign&&!rem.isAbsZero()){
        obj2.sign=false;
        rem.sign=true;
        return rem+obj2;
      
      }      
    return rem;
  }
  //-------------------------relational operator-------------------
  bool operator>=(BigInt obj){
  
      BigInt temp;
      temp=*this-obj;
      return !temp.sign;  
  }
  bool operator>(BigInt obj){
  
      BigInt temp;
      temp=obj-*this;
      return temp.sign;  
  }
  bool operator<(BigInt obj){
  
      BigInt temp;
      temp=*this-obj;
      return temp.sign;  
  }
  bool operator<=(BigInt obj){
  
      BigInt temp;
      temp=obj-*this;
      return !temp.sign;  
  }
  bool operator==(BigInt obj){
  
      BigInt temp;
      temp=obj-*this;
      return temp.isAbsZero();  
  }
  //-------------------------------------------------------
  void show(){
    
      int i;
    
      for(i=strlen(operand)-1;operand[i]=='0'&&i>0;i--)
        ;
      if(sign&&(i||operand[i]!='0'))
          printf("-");
      for(;i>=0;i--)
        printf("%c",operand[i]);
      printf("\n");
  }
};


int main() {
//  freopen("_in.txt", "r", stdin);
  int i,n;

  BigInt num[5001];
  num[0] = BigInt("0");
  num[1] = BigInt("1");
  
  for (i=2; i<5001; i++) {
    num[i] = num[i-1] + num[i-2];
  }
  
  while (scanf("%d", &n) != EOF) {
    printf("The Fibonacci number for %d is ", n);
    num[n].show();
  }
  return 0;
}

/*
    memset(arrayName, 255, )  
    cout.setf (ios::fixed, ios::floatfield);
    cout.setf(ios::showpoint);
    cout<<setprecision(2)<<sum_c + eps<<endl;

*/
