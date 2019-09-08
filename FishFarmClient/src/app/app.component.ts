import { Component, OnInit, Pipe } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { FishFarmService } from './services/fishfarm.service';
import { debug } from 'util';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements  OnInit {
  constructor(private fishFarmService:FishFarmService){

  }
  allFishes=[];
  allTanks=[];
  displayFishes=[];
  selectedFish={fid:null,tid:null};
  showDetailColumn="none";

  ngOnInit(){
   this.allTanks= this.fishFarmService.getTanks();
   this.allFishes=this.fishFarmService.getFishes();
  };

  loadFishesOfTank(tank)
  {
    for (let index = 0; index < this.allTanks.length; index++) {
        this.allTanks[index].selected=false;;
    }
    tank.selected=true;
    this.displayFishes=[];
    this.displayFishes = this.allFishes.filter(function(fish){
      if(fish.tid==tank.tid){
        return fish;
      }
    });
    this.showDetailColumn="none";
  };

  isTankFulled(tid){
    var fishesInTank = this.getFishesInTank(tid);
    return fishesInTank.length >= 3;
  };
  
  fishDetails(fish){
    this.selectedFish=fish;
    this.searchword=false;
    this.showDetailColumn="block";
    var alowedTanks = this.getAlowedDestinationTanks(this.selectedFish);
    this.availableLocation= this.fishFarmService.makeDynmicDropDown(alowedTanks);
  };

  getAlowedDestinationTanks(fish){
    var alowedTanks = this.allTanks.filter(t=> {
      if(t.tid != fish.tid){
        var fishesInTank = this.getFishesInTank(t.tid);
        if(fishesInTank.length < 3){
          return t;
        }
      }
    })
    return alowedTanks;
  };
  
  getFishesInTank(tid){
    return this.allFishes.filter(function(fish){
      if(fish.tid == tid){
        return fish;
      }
    });
  };

  availableLocation;
  selectFish;

  moveFish(){
    let selectElement:any =  document.querySelector('#drpLocation');
    let fishId = this.selectedFish.fid;
    let fromTankId= this.selectedFish.tid;
    let toTankId = selectElement.value;
    
    this.allFishes.forEach(function(fish){
      if(fish.fid == fishId){
        fish.tid = toTankId;
      }
    });
    this.displayFishes = this.displayFishes.filter(f=>{
      if(f.fid != fishId){
        return f;
      }
    });;

    this.showDetailColumn="none";
    this.availableLocation="";
    this.saveMovementHistory(fishId,fromTankId,toTankId);
  };

  history=[];
  saveMovementHistory(fid, fromTankId, toTankId){
    let obj={fish:fid, fromTank: fromTankId, toTank:toTankId, date:new Date()};
    this.history.push(obj);
    this.fishFarmService.saveMovementHistory(this.history);
  };

  myHistorylist=[];
  myHistory(fid){
  this.myHistorylist = this.fishFarmService.getMovementHistory(fid);
  };

  searchText;
  searchword=false;
  onKeydown(event) {
  let  word=event.key;
    if (event.key != "Enter" && event.key != "Backspace") {
    }
    else if(event.key === "Backspace"){
    }
    else if(event.key === "Enter"){
      debugger;
      word=this.searchText;
      var firstFoundFish= this.allFishes.find(f=>f.fid.toLowerCase()==word.toLowerCase());
      if(firstFoundFish)
      {
        this.searchword=true;
        this.displayFishes=[];
        let findobject=JSON.stringify(firstFoundFish);
        let object=JSON.parse(findobject);
        object.fid=[];
        object.fid.push(word.toLowerCase());
        this.displayFishes.push(object);

        for (let index = 0; index < this.allTanks.length; index++) {
          this.allTanks[index].selected=false;
        }
        this.allTanks.forEach(function(tank){
          if(tank.tid ==firstFoundFish.tid){
            tank.selected=true;
          }
        })
      }
    }
  };
  
}
@Pipe({name: 'safeHtml'})
export class Safe {
  constructor(private sanitizer:DomSanitizer){}
  transform(value: any, args?: any): any {
    return this.sanitizer.bypassSecurityTrustHtml(value);
  }
}