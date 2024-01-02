export interface datasourcerequest{
    take: number,
    skip: number,
    sort: [
      {
        field: string,
        dir: string
      }
    ],
    filter: {
      field: string,
      operator: string,
      value: string,
      logic: string,
      filters: [
        string
      ]
    },
    group: [
      {
        field: string,
        dir: string,
        aggregates: [
          {
            field: string,
            aggregate: string
          }
        ]
      }
    ],
    aggregate: [
      {
        field: string,
        aggregate: string
      }
    ]
  }