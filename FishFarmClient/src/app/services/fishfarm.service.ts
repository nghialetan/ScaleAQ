import { Injectable } from "@angular/core";
@Injectable()
export class FishFarmService {

    constructor() {

    }
    getFishesForTank(tankId){
      //Todo
    };
    getFishById(fishId){
      //Todo
    };
    updateFish(fish){
      //Todo
    };
    getAllowedDestinationTanks(fishId){
      //Todo
    };
    moveFish(fishId, toTankId){
      //Todo
    };
    getTanks(){
      let tankList=[];
      for (let index = 0; index < 10; index++) {
          tankList.push({tid:"t"+index,selectd:false});
        }
        return tankList;
    };
    getFishes(){
        let fishList=[];
        for (let index = 0; index < 10; index++) {
            fishList.push({fid:"f"+index, tid:"t"+index});
          }
          return fishList;
    };
    saveMovementHistory(history){
      localStorage.setItem("history",JSON.stringify(history))
    };
    getMovementHistory(fish){
        const history=JSON.parse(localStorage.getItem("history"));
        return history.filter(x=>{
          return x.fish==fish;
        })
    };
    makeDynmicDropDown(tanks){
        let availableLocation='';
        availableLocation=`<select  class="form-control" id="drpLocation">`;
        availableLocation+="<option disabled selected>Select Tank</option>"
        tanks.forEach(function(tank){
          availableLocation+=`<option value=${tank.tid}>Tank ${tank.tid}</option>`;
        })
        
       availableLocation+=` </select>`
       return availableLocation;
    };
    
}