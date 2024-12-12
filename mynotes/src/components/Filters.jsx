import { Input,SelectContent, SelectItem, SelectRoot, SelectTrigger, SelectValueText, createListCollection } from '@chakra-ui/react';

export default function Filters({filter, setFilter}) {
    return (
        <div className='flex flex-col gap-5'>
                <Input placeholder='Поиск' onChange={(e) => setFilter({...filter, search: e.target.value})}/>
                <SelectRoot collection={orderBy} size="sm" width="320px" className='py-3'>
              <SelectTrigger>
                <SelectValueText placeholder={orderBy.items.find((item) => item.value === filter.sortOrder)?.label || "Выберите сортировку"} />
              </SelectTrigger>
              <SelectContent>
          {orderBy.items.map((item) => (
            <SelectItem
              key={item.value}
              onClick={() =>
                setFilter({ ...filter, sortOrder: item.value })
              }
            >
              {item.label}
            </SelectItem>
          ))}
        </SelectContent>
            </SelectRoot>
            </div>
    )
}
const orderBy = createListCollection({
    items: [
      { label: "Сначала новые", value: "desc" },
      { label: "Сначала старые", value: "asc" },
    ],
  })