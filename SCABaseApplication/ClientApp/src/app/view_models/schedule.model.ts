
export interface ISchedule {
  teammateName:	string
  teammateType:	string
  monday:	string
  tuesday:	string
  wednesday:	string
  thursday:	string
  friday:	string
  saturday:	string
  sunday:	string
}

export class Schedule implements ISchedule {
  teammateName: string
  teammateType: string
  monday: string
  tuesday: string
  wednesday: string
  thursday: string
  friday: string
  saturday: string
  sunday: string
}
