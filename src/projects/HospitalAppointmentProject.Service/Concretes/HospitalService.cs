using AutoMapper;
using HospitalAppointmentProject.DataAccess.Repositories.Abstracts;
using HospitalAppointmentProject.Model.Dtos.Hospitals;
using HospitalAppointmentProject.Model.Entities;
using HospitalAppointmentProject.Service.Abstracts;
using HospitalAppointmentProject.Service.BusinessRules.Hospitals;
using HospitalAppointmentProject.Service.Constants.Hospitals;

namespace HospitalAppointmentProject.Service.Concretes;

public class HospitalService : IHospitalService
{
    private readonly IHospitalRepository _hospitalRepository;
    private readonly IMapper _mapper;
    private readonly HospitalBusinessRules _businessRules;

    public HospitalService(IHospitalRepository hospitalRepository, IMapper mapper, HospitalBusinessRules businessRules)
    {
        _hospitalRepository = hospitalRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<string> AddAsync(HospitalAddRequestDto dto, CancellationToken cancellationToken = default)
    {
        await _businessRules.HospitalNameMustBeUniqueAsync(dto.Name);
        Hospital hospital = _mapper.Map<Hospital>(dto);
        await _hospitalRepository.AddAsync(hospital);
        return HospitalMessages.HospitalAddedMessage;
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        await _businessRules.HopitalIsPresentAsync(id);

        Hospital hospital = await _hospitalRepository.GetAsync(filter: x => x.Id == id, include: false, cancellationToken: cancellationToken);

        await _hospitalRepository.DeleteAsync(hospital, cancellationToken);
    }

    public async Task<List<HospitalResponseDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        List<Hospital> hospitals = await _hospitalRepository.GetAllAsync(enableTracking: false, cancellationToken: cancellationToken);
        var hospitalResponseDtos = _mapper.Map<List<HospitalResponseDto>>(hospitals);
        return hospitalResponseDtos;
    }

    public async Task<HospitalResponseDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        await _businessRules.HopitalIsPresentAsync(id);
        Hospital hospital = await _hospitalRepository.GetAsync(filter: x => x.Id == id, enableTracking: false, cancellationToken: cancellationToken);
        var hospitalResponseDtos = _mapper.Map<HospitalResponseDto>(hospital);
        return hospitalResponseDtos;
    }

    public async Task UpdateAsync(HospitalUpdateRequestDto dto, CancellationToken cancellationToken = default)
    {
        await _businessRules.HopitalIsPresentAsync(dto.Id);
        ////Movie movie = await _movieRepository.GetAsync(filter: x => x.Id == dto.Id, include: false, cancellationToken: cancellationToken);
        Hospital hospital = _mapper.Map<Hospital>(dto);
        await _hospitalRepository.UpdateAsync(hospital, cancellationToken);
    }
}
